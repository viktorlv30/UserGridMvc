using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserGridMvc.BLL.Implementations;
using UserGridMvc.DAL.Repositories.Implementations;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.Util
{
    public class Helper
    {
        public bool IsUserValid(User user)
        {
            if (!IsUserEntityValid(user))
                return false;
            if (!IsPhoneValid(user.Phone))
                return false;
            if (!IsEmailValid(user.Email))
                return false;
            if (!IsAddressValid(user.Address))
                return false;

            return true;
        }

        public bool IsUserEntityValid(User user)
        {
            if (!IsValidName(user.FirstName.Trim()) || user.FirstName.Trim().Length >= 50)
                return false;
            if (user.LastName != null && (!IsValidName(user.LastName.Trim()) || user.LastName.Trim().Length >= 50))
                return false;
            return true;
        }

        public bool IsUniqueLogin(string login)
        {
            var userBl = new UserBl(new UserRepository());
            return !userBl.Get(x => x.Login == login).Any();
        }

        public bool IsValidName(string name)
        {
            Regex r = new Regex("^[a-zA-Z_ ]*$");
            if (r.IsMatch(name))
            {
                return true;
            }
            return false;
        }

        public bool IsEmailValid(Email email)
        {
            var isValid = true;
            if (!IsTypeCommunicationValid(email.Type))
                return false;

            isValid = Regex.IsMatch(email.Mail,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);

            return isValid;
        }

        public bool IsPhoneValid(Phone phone)
        {
            var isValid = true;
            if (!IsTypeCommunicationValid(phone.Type))
                return false;

            isValid = Regex.IsMatch(phone.Number.ToString(), @"^([0-9]{5,9})$");

            return isValid;
        }

        public bool IsAddressValid(Address address)
        {
            if (!IsTypeCommunicationValid(address.Type))
                return false;
            if(address.PostAddress != null && address.PostAddress.Trim().Length > 200)
                return false;

            return true;
        }

        public bool IsTypeCommunicationValid(string type)
        {
            if (type != null && type.Length > 200)
                return false;

            return true;
        }
    }
}
