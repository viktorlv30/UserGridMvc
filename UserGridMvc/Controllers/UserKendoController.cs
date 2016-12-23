using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using UserGridMvc.Models;

namespace UserGridMvc.Controllers
{
    public class UserKendoController : Controller
    {
        private readonly UserKendoModel _userKendo;

        public UserKendoController()
        {
            _userKendo = new UserKendoModel();
        }

        // GET: UserKendo
        public ActionResult Editing_Popup()
        {
            return View("UserKendo");
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_userKendo.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, UserKendoModel userKendo)
        {
            if (userKendo != null && ModelState.IsValid)
            {
                _userKendo.Create(userKendo);
            }

            return Json(new[] { userKendo }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, UserKendoModel userKendo)
        {
            if (userKendo != null && ModelState.IsValid)
            {
                _userKendo.Update(userKendo);
            }

            return Json(new[] { userKendo }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, UserKendoModel userKendo)
        {
            if (userKendo != null)
            {
                _userKendo.Delete(userKendo);
            }

            return Json(new[] { userKendo }.ToDataSourceResult(request, ModelState));
        }
    }
}