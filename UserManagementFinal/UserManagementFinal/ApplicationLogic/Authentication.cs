using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.ApplicationLogic.Validations;
using UserManagementFinal.Database.Models;
using UserManagementFinal.Database.Models.Repository;

namespace UserManagementFinal.ApplicationLogic
{
    class Authentication
    {
        public static void Register()
        {
            string name = UserValidation.GetName();
            string lastName = UserValidation.GetLastName();
            string email = UserValidation.GetEmail();
            string password = UserValidation.GetPassword();

            User user = UserRepository.AddUser(name, lastName, email, password);
            Console.WriteLine($"User added to sytstem {user.GetUserInfo()}");

        }

        public static void Login()
        {
            while (true)
            {
                Console.Write("Pls enter email : ");
                string email = Console.ReadLine();
                Console.Write("Pls enter password : ");
                string password = Console.ReadLine();
                if (UserRepository.IsUserExistsByEmailAndPassword(email, password))
                {

                    User user = UserRepository.GetByEmail(email);

                    if (user != null)
                    {
                        Dashboard.CurrentUser = user;
                        if (user is Admin)
                        {
                            Dashboard.AdminPanel(email);
                        }
                        else if (user is User)
                        {
                            Dashboard.UserPanel(email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Istifadeci tapilmadi");
                    }


                    if (user is Admin)
                    {
                        Dashboard.AdminPanel(email);
                    }
                    else if (user is User)
                    {
                        Dashboard.UserPanel(email);
                    }
                    else
                    {
                        Console.WriteLine("User");
                    }
                }
                else
                {
                    Console.WriteLine("Email or password not correct.");
                }

            }
        }
    }
}
