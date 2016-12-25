using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.Models
{
    public class UserModel
    {
        // User ID
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        // User login
        [Required]
        [DisplayName("Логин")]
        [StringLength(50, ErrorMessage = "Введите логин от 1 до 50 символов")]
        public string Login { get; set; }

        // User name
        [Required]
        [DisplayName("Полное Имя")]
        [StringLength(50, ErrorMessage = "Введит имя от 1 до 50 символов ('Вася Пупкин')")]
        public string Name { get; set; }

        // user status - IsDeleted
        [DisplayName("Удалить пользователя?")]
        public bool Status { get; set; }

        // user phones
        [DisplayName("Телефон (+380..)")]
        [Range(0, int.MaxValue, ErrorMessage = "Номер должен иметь 9 цифр")]
        public int Phone { get; set; }

        // user emailes
        [Required]
        [DisplayName("Email")]
        [StringLength(200, ErrorMessage = "Введит email от 1 до 200 символов")]
        public string Email { get; set; }

        // user addresses
        [DisplayName("Почтовый адрес")]
        [StringLength(200, ErrorMessage = "Введит адрес от 1 до 200 символов")]
        public string Address { get; set; }

        public void SetChangedData(ref User user)
        {
            if (user.IsDeleted != this.Status)
                user.IsDeleted = this.Status;
            if (user.Login != this.Login)
                user.Login = this.Login;
            if (user.FirstName != this.Name.Trim().Split(' ')[0])
                user.FirstName = this.Name.Trim().Split(' ')[0];
            try
            {
                if (user.LastName != this.Name.Trim().Split(' ')[1])
                    user.LastName = this.Name.Trim().Split(' ')[1];
            }
            catch
            {
                user.LastName = null;
            }
            
            if (user.Phone.Number != this.Phone)
                user.Phone.Number = this.Phone;
            if (user.Email.Mail != this.Email)
                user.Email.Mail = this.Email;
            if (user.Address.PostAddress != this.Address)
                user.Address.PostAddress = this.Address;
        }
    }
}