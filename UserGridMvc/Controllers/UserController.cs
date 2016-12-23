using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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

        public UserController()
        {
            _userBl = new UserBl(new UserRepository());
            _temporaryCounter++;

            
            //for grid testing
            if (_temporaryCounter < 0)
            {
                foreach (var user in _userBl.GetAll().ToList())
                {
                    user.IsDeleted = false;
                    _userBl.UpdateUser(user);
                }

                _userBl.CreateNewUser(new User
                {
                    FirstName = "FFFFF",
                    LastName = "GGGGGGG",
                    Login = "fffffffff"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "DDD",
                    LastName = "AAAAA",
                    Login = "dddddddddd"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "WWWWWWW",
                    LastName = "QQQQQQQ",
                    Login = "wwwwwwww"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "TTTTTTT",
                    LastName = "YYYYYY",
                    Login = "tttttttt"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "UUUUU",
                    LastName = "IIIII",
                    Login = "uuuuuuuu"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "RRRRRRRR",
                    LastName = "EEEEEEEEE",
                    Login = "rrrrrrrr"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "IIIIIII",
                    LastName = "OOOOOOO",
                    Login = "iiiiiiii"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "TTTTTT",
                    LastName = "NNNNNN",
                    Login = "ggggggggg"
                });
                _userBl.CreateNewUser(new User
                {
                    FirstName = "KKKK",
                    LastName = "MMMM",
                    Login = "11111"
                });
            }
            
        }

        // GET: User
        public ActionResult Show()
        {
            var usersDb = _userBl.Get(u => u.IsDeleted == false).ToList();

            var users = usersDb.Select(user => new UserModel().ConvertUserToModel(user)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Name);

            return PartialView("UserList", users);
            //return View("Show");
        }

        // add user initial screen
        [HttpGet]
        public ActionResult Create()
        {
            var addTeacherModel = new UserModel();
            return PartialView("UserEdit", addTeacherModel);
        }

        // updating a teaher in the DB
        [HttpPost]
        public ActionResult Create(UserModel addedUser)
        {
            if (addedUser.Name == null || addedUser.Name.Length > 102 ||
                addedUser.Login == null || addedUser.Login.Length > 50)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var newUser = new User()
            {
                FirstName = addedUser.Name.Split(' ')[0],
                LastName = addedUser.Name.Split(' ')[1],
                Login = addedUser.Login,
                Address = new Address {PostAddress = addedUser.Address},
                Phone = new Phone{Number = addedUser.Phone},
                Email = new Email{Mail= addedUser.Email},
                
            };

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

            return PartialView("UserEdit", updateUserModel);
        }

        // updating a teaher in the DB
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
