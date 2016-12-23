using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserGridMvc.BLL.Implementations;
using UserGridMvc.DAL.Repositories.Implementations;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.Models
{
    public class UserKendoModel
    {
        private static bool _updateDatabase = false;
        private readonly UserBl _userBl;
        private int _counter;

        //UserKendoModel
        // User ID
        public Guid Id { get; set; }

        // User number
        public int Number { get; set; }

        // User login
        public string Login { get; set; }

        // User name
        public string Name { get; set; }

        // user status - IsDeleted
        public bool Status { get; set; }

        // user phones
        public int Phone { get; set; }

        // user emailes
        //public List<Email> Emailes { get; set; }
        public string Email { get; set; }

        // user addresses
        public string Address { get; set; }

        public UserKendoModel(/*UserBl userBl*/)
        {
            _userBl = new UserBl(new UserRepository());// = userBl;
            _counter = 0;
        }
        
        // convert User to a UserModel for a view
        public UserKendoModel ConvertUserToModel(User userToConvert)
        {
            Id = userToConvert.Id;
            Number = ++_counter;
            Login = userToConvert.Login;
            Name = userToConvert.FirstName + " " + userToConvert.LastName;
            Status = userToConvert.IsDeleted;
            Email = userToConvert.Email?.Mail ?? "doesn't have email";
            Phone = userToConvert.Phone?.Number ?? 0;
            Address = userToConvert.Address?.PostAddress ?? "doesn't have post address";

            return this;
        }

        

        public IList<UserKendoModel> GetAll()
        {
            var users = _userBl.GetAll().ToList();
            return users.Select(ConvertUserToModel).ToList();
        }

        public IEnumerable<UserKendoModel> Read()
        {
            return GetAll();
        }

        public void Create(UserKendoModel userKendo)
        {
            if (!_updateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.Number).FirstOrDefault();
                var id = first?.Number ?? 0;

                userKendo.Number = id + 1;

                GetAll().Insert(0, userKendo);
            }
            else
            {
                var user = new User
                {
                    FirstName = userKendo.Name.Split(' ')[0],
                    LastName = userKendo.Name.Split(' ')[1],
                    Login = userKendo.Login,
                    IsDeleted = false,
                    Email = {Mail = userKendo.Email},
                    Phone = {Number = userKendo.Phone},
                    Address = {PostAddress = userKendo.Address}
                };

                _userBl.CreateNewUser(user);

                userKendo.Id = user.Id;
                userKendo.Number = ++_counter;
            }
        }

        public void Update(UserKendoModel userKendo)
        {
            if (!_updateDatabase)
            {
                var target = One(e => e.Id == userKendo.Id);

                if (target != null)
                {
                    target.Name = userKendo.Name;
                    target.Login = userKendo.Login;
                    target.Email = userKendo.Email;
                    target.Phone = userKendo.Phone;
                    target.Address = userKendo.Address;
                    target.Status = userKendo.Status;
                }
            }
            else
            {
                var user = new User
                {
                    FirstName = userKendo.Name.Split(' ')[0],
                    LastName = userKendo.Name.Split(' ')[1],
                    Login = userKendo.Login,
                    IsDeleted = false,
                    Email = {Mail = userKendo.Email},
                    Phone = {Number = userKendo.Phone},
                    Address = {PostAddress = userKendo.Address}
                };

                _userBl.UpdateUser(user);
            }
        }

        public void Delete(UserKendoModel userKendo)
        {
            if (!_updateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.Id == userKendo.Id);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var user = new User();

                user.Id = userKendo.Id;

                _userBl.GetById(user.Id);

                _userBl.DeleteUser(user);

            }
        }

        public UserKendoModel One(Func<UserKendoModel, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        
    }
}