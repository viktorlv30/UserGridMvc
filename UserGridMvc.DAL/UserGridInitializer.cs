using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using UserGridMvc.Entity.Entities;

namespace UserGridMvc.DAL
{
    public class UserGridInitializer : CreateDatabaseIfNotExists<UserGridDbContext>
    {
        protected override void Seed(UserGridDbContext context)
        {
            try
            {
                

                var defaultPhones = new List<Phone>
                    {
                        new Phone
                        {
                            Number = 979471594,
                            Type = "kyivstar",
                            //User = context.Users.FirstOrDefault(u => u.Login == "vik")
                        },
                        new Phone
                        {
                            Number = 630001594,
                            Type = "lifecell",
                            //User = context.Users.FirstOrDefault(u => u.Login == "vik")
                        }
                    };
                foreach (var item in defaultPhones)
                    context.Phones.Add(item);
                //context.SaveChanges();

                var defaultEmails = new List<Email>
                    {
                        new Email
                        {
                            Mail = "viktor@piktor.ua",
                            Type = "for spam",
                            //User = context.Users.FirstOrDefault(u => u.Login == "vik")
                        },
                        new Email
                        {
                            Mail = "vikysik@love.com",
                            Type = "for love",
                            //User = context.Users.FirstOrDefault(u => u.Login == "vik")
                        }
                    };
                foreach (var item in defaultEmails)
                    context.Emails.Add(item);
                //context.SaveChanges();

                var defaultAddr = new Address
                {
                    PostAddress = "21000, 30-A Spacemen, Vinnitsya",
                    Type = "for work",
                    //User = context.Users.FirstOrDefault(u => u.Login == "vik")
                };

                context.Addresses.Add(defaultAddr);
                context.SaveChanges();

                var defaultUser = new User()
                {
                    Login = "vik",
                    FirstName = "Vitya",
                    LastName = "Litvak",
                    Phone = context.Phones.FirstOrDefault(p => p.Number == 630001594),
                    Email = context.Emails.FirstOrDefault(p => p.Mail == "viktor@piktor.ua"),
                    Address = context.Addresses.FirstOrDefault(p => p.PostAddress == "21000, 30-A Spacemen, Vinnitsya"),

                };
                context.Users.Add(defaultUser);
                context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }

            base.Seed(context);
        }
    }
}