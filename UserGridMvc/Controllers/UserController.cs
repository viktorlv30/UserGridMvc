using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using UserGridMvc.BLL.Implementations;
using UserGridMvc.DAL.Repositories.Implementations;
using UserGridMvc.Entity.Entities;
using UserGridMvc.Models;

namespace UserGridMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBl _userBl;
        //this counter for grid testing
        private static int _temporaryCounter = 0;
        private static bool _isDeletedVisible = false;

        public UserController()
        {
            _userBl = new UserBl(new UserRepository());
            
        }

        // GET: User
        public ActionResult Show()
        {
            //var usersDb = _userBl.Get(u => u.IsDeleted == false).ToList();

            //var users = usersDb.Select(user => new UserModel().ConvertUserToModel(user)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Name);

            //return PartialView("UserList", users);
            return PartialView("UserList");
            //return View("Show");
        }

        public ActionResult GetPersons([DataSourceRequest] DataSourceRequest dsRequest)
        {
            var usersDb = _userBl.Get(u => u.IsDeleted == _isDeletedVisible).ToList();
            var users = usersDb.Select(user => new UserModel().ConvertUserToModel(user)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Name);
            var result = users.ToDataSourceResult(dsRequest);

            _isDeletedVisible = false;

            return Json(result);
        }

        public ActionResult UpdatePerson([DataSourceRequest] DataSourceRequest dsRequest, UserModel userModel)
        {
            //ModelState.Remove(userModel.Id.ToString());
            //ModelState.Remove(userModel.Status.ToString());
            //ModelState.Remove(userModel.Phone.ToString());
            //ModelState.Remove(userModel.Email);
            //ModelState.Remove(userModel.Address);

            if(ModelState.IsValid)
            {
                var userFromDb = _userBl.Get(u => u.Id == userModel.Id).FirstOrDefault();
                userModel.SetChangedData(ref userFromDb);
               _userBl.UpdateUser(userFromDb);
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult ShowAll()
        {
            //var usersDb = _userBl.GetAll().ToList();

            //var users = usersDb.Select(user => new UserModel()
            //                    .ConvertUserToModel(user))
            //                    .ToList()
            //                    .OrderBy(x => x.Name);
            _isDeletedVisible = true;

            return PartialView("UserList"/*, users*/);
            //return View("Show");
        }

        // add user initial screen
        [HttpGet]
        public ActionResult Create()
        {
            var addUserModel = new UserModel();
            return PartialView("UserList", addUserModel);
        }

        // updating a teaher in the DB
        [HttpPost]
        public ActionResult Create(UserModel addedUser)
        {
            if (addedUser.Name?.Trim().Split(' ')[0] == null || addedUser.Name.Trim().Length > 102 || addedUser.Name.Trim().Length < 1
                || addedUser.Login == null || addedUser.Login.Length > 50 || addedUser.Email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var newUser = UserModel.ConverModelToUser(addedUser);

            _userBl.Insert(newUser);

            return RedirectToAction("Show");
        }

        // action gets triggered once admin clicked on the Update
        // button of a particular teacher on the list of teachers
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var updateUserModel = new UserModel();
            updateUserModel.ConvertUserToModel(user);

            return PartialView("UserList", updateUserModel);
        }

        // updating a user in the DB
        [HttpPost]
        public ActionResult Edit(UserModel updatedUser)
        {
            var user = _userBl.GetById(updatedUser.Id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Show");
        }

        // Delete a user
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _userBl.DeleteUser(user);
            return RedirectToAction("Show");
        }

    }
}
