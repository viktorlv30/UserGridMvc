using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserGridMvc.BLL.Implementations;
using UserGridMvc.DAL.Repositories.Implementations;
using UserGridMvc.Models;

namespace UserGridMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBl _userBl;

        public UserController()
        {
            _userBl = new UserBl(new UserRepository());
        }

        // GET: User
        public ActionResult Show()
        {
            var usersDb = _userBl.GetAll().ToList();

            var users = usersDb.Select(user => new UserModel().ConvertUserToModel(user)).ToList().OrderBy(x => x.Status).ThenBy(x => x.FirstName);

            return PartialView("UserList", users);
            //return View("Show");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return PartialView("UserList");
            //return View("Show");
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return PartialView("UserList");
            //return View("Show");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Show");
            }
            catch
            {
                return PartialView("UserList");
                //return View("Show");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView("UserList");
            //return View("Show");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Show");
            }
            catch
            {
                return PartialView("UserList");
                //return View("Show");
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView("UserList");
            //return View("Show");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Show");
            }
            catch
            {
                return PartialView("UserList");
                //return View("Show");
            }
        }
    }
}
