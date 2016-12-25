using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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

        //get users from db: only active if 'Show' action is called and all users if is called 'ShowAll' action
        public ActionResult GetPersons([DataSourceRequest] DataSourceRequest dsRequest)
        {
            //map User entity to UserModel entity
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserModel>()
                .ForMember("Name", opt => opt.MapFrom(u => u.FirstName + " " + u.LastName))
                .ForMember("Status", opt => opt.MapFrom(u => u.IsDeleted))
                .ForMember("Phone", opt => opt.MapFrom(u => u.Phone.Number))
                .ForMember("Email", opt => opt.MapFrom(u => u.Email.Mail))
                .ForMember("Address", opt => opt.MapFrom(u => u.Address.PostAddress)));

            var usersToModel =
                Mapper.Map<IEnumerable<User>, List<UserModel>>(_userBl.Get(u => u.IsDeleted == _isDeletedVisible).ToList());

            var result = usersToModel.ToDataSourceResult(dsRequest);

            _isDeletedVisible = false;

            return Json(result);
        }

        //update user from client
        public ActionResult UpdatePerson([DataSourceRequest] DataSourceRequest dsRequest, UserModel userModel)
        {
            //map UserModel  entity to User entity
            Mapper.Initialize(cfg => cfg.CreateMap<UserModel, User>()
                .ForMember("FirstName", opt => opt.MapFrom(src => src.Name.Trim().Split(' ')[0]))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Name.Trim().Split(' ').Length > 1
                                                                ? src.Name.Trim().Split(' ')[1] : ""))
                .ForMember("IsDeleted", opt => opt.MapFrom(u => u.Status))
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(u => new Phone { Number = u.Phone }))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(u => new Email { Mail = u.Email }))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(u => new Address { PostAddress = u.Address })));

            var userToUpdate = Mapper.Map<UserModel, User>(userModel);

            //call Helper to validate data
            var helper = new Helper();
            if (ModelState.IsValid && helper.IsUserValid(userToUpdate))
            {
                //get user from db to update entity
                var userFromDb = _userBl.Get(u => u.Id == userModel.Id).FirstOrDefault();
                //change entity and save to db
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

        //show all user include 'deleted'
        public ActionResult ShowAll()
        {
            _isDeletedVisible = true;
            return PartialView("UserList");
        }

        // create a user
        [HttpPost]
        public ActionResult Create(UserModel addedUser)
        {
            //map UserModel  entity to User entity
            Mapper.Initialize(cfg => cfg.CreateMap<UserModel, User>()
                .ForMember("FirstName", opt => opt.MapFrom(src => src.Name.Trim().Split(' ')[0]))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Name.Trim().Split(' ').Length > 1
                                                                ? src.Name.Trim().Split(' ')[1] : ""))
                .ForMember("IsDeleted", opt => opt.MapFrom(u => u.Status))
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(u => new Phone { Number = u.Phone }))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(u => new Email { Mail = u.Email }))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(u => new Address { PostAddress = u.Address })));

            //exclude unnecessary field from ModelSatte validation
            ModelState.Remove("Id");
            ModelState.Remove("Phone");

            var userToCreate = Mapper.Map<UserModel, User>(addedUser);
            var helper = new Helper();

            if (ModelState.IsValid && helper.IsUserValid(userToCreate))
            {
                var newUser = Mapper.Map<UserModel, User>(addedUser);
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

        //set user entity as deleted (IsDelete = true)
        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest dsRequest, UserModel userModel)
        {
            var userFromDb = _userBl.Get(u => u.Id == userModel.Id).FirstOrDefault();
            _userBl.DeleteUser(userFromDb);

            return RedirectToAction("ShowAll");
        }

    }
}
