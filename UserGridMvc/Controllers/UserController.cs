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
using UserGridMvc.Util;

namespace UserGridMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBl _userBl;
        private static bool _isDeletedVisible = false;

        public UserController()
        {
            _userBl = new UserBl(new UserRepository());
        }

        public ActionResult Show()
        {
            return PartialView("UserList");
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
            var userToUpdate = UserModel.ConverModelToUser(userModel);
            var helper = new Helper();
            ModelState.Remove("Phone");
            if (ModelState.IsValid && helper.IsUserValid(userToUpdate))
            {
                var userFromDb = _userBl.Get(u => u.Id == userModel.Id).FirstOrDefault();
                userModel.SetChangedData(ref userFromDb);
                _userBl.UpdateUser(userFromDb);
                return RedirectToAction("Show");
            }
            else
            {
                ModelState.AddModelError(/* Property name */ "Update", /* Validation message */ "Update user error");
                return Json(ModelState.ToDataSourceResult());
            }
        }

        public ActionResult ShowAll()
        {
            _isDeletedVisible = true;
            return PartialView("UserList");
        }

        // create a user
        [HttpPost]
        public ActionResult Create(UserModel addedUser)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Phone");
            var userToCreate = UserModel.ConverModelToUser(addedUser);
            var helper = new Helper();

            if (ModelState.IsValid && helper.IsUserValid(userToCreate))
            {
                var newUser = UserModel.ConverModelToUser(addedUser);
                var isSameUserAlreadyExist = _userBl.IsSuchUserExist(newUser);

                if (!isSameUserAlreadyExist)
                    _userBl.Insert(newUser);

                return RedirectToAction("Show");
            }
            else
            {
                ModelState.AddModelError(/* Property name */ "Create", /* Validation message */ "Create user error");
                return Json(ModelState.ToDataSourceResult());
            }
        }


        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest dsRequest, UserModel userModel)
        {
            var userFromDb = _userBl.Get(u => u.Id == userModel.Id).FirstOrDefault();
            _userBl.DeleteUser(userFromDb);

            return RedirectToAction("ShowAll");
        }

    }
}
