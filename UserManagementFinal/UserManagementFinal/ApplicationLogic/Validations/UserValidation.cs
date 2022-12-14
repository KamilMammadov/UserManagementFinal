using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Repository;

namespace UserManagementFinal.ApplicationLogic.Validations
{
    class UserValidation
    {

        public static bool IsNameValid(string name)
        {
            string patterms = "^[A-Z][a-zA-z]{3,30}$";
            Regex regex = new Regex(patterms);
            if (regex.IsMatch(name))
            {
                return true;
            }
            Console.WriteLine("The name you entered is incorrect, make sure the name contains only letters, the first letter is capitalized, and the length is greater than 3 and less than 30.");
            return false;
        }

        public static bool IsLastNameValid(string lastName)
        {
            string patterms = "^[A-Z][a-zA-z]{3,30}$";
            Regex regex = new Regex(patterms);
            if (regex.IsMatch(lastName))
            {
                return true;
            }
            Console.WriteLine("The surnam you entered is incorrect, make sure the name contains only letters, the first letter is capitalized, and the length is greater than 3 and less than 30.");

            return false;
        }

       
        public static bool IsValidEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9]{10,30}@code\.edu\.az") && UserRepository.IsEmailExists(email))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Email must be like useruser@code.edu.az");
            }
            return false;
        }

        public static bool IsUserExistsByEmail(string email)
        {
            if (!UserRepository.IsEmailExists(email))
            {
                return true;
            }
            Console.WriteLine("Email already exists");
            return false;
        }

        public static bool IsPasswordValid(string password)
        {
            string patterns = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            Regex regexpassword = new Regex(patterns);
            if (regexpassword.IsMatch(password))
            {
                return true;
            }
            Console.WriteLine("In password must be one Upper case , one lower case , and pass must be upper than 8");
            return false;
        }

        public static bool IsPasswordSame(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            Console.WriteLine("Passwords not same .....");
            return false;
        }

        public static string GetName()
        {
            bool isEceptionValid;
            string name = null;
            do
            {

                try
                {
                    Console.Write("Insert Name : ");
                    name = Console.ReadLine();
                    if (name == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Seflik var");
                }

            } while (isEceptionValid || !UserValidation.IsNameValid(name));


            return name;
        }
        public static string GetLastName()
        {
            bool isEceptionValid;
            string surname = null;
            do
            {

                try
                {
                    Console.Write("Insert Surname : ");
                    surname = Console.ReadLine();
                    if (surname == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Seflik var");
                }

            } while (isEceptionValid || !UserValidation.IsNameValid(surname));


            return surname;
        }
        public static string GetEmail()
        {
            string email = null;
            bool isExceptionValid;
            do
            {
                try
                {

                    Console.Write("Insert email : ");
                    email = Console.ReadLine();

                    if (email == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch (Exception)
                {
                    isExceptionValid = true;
                    Console.WriteLine("Xeta var"); ;
                }

            } while (isExceptionValid ||!UserValidation.IsValidEmail(email));
            return email;
           
        }
        public static string GetPassword()
        {
            string password = null;
            bool isExceptionValid;
            do
            {
                try
                {

                    Console.Write("Insert password : ");
                    password = Console.ReadLine();

                    if (password == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch (Exception)
                {
                    isExceptionValid = true;
                    Console.WriteLine("Xeta var"); ;
                }

            } while (isExceptionValid || !UserValidation.IsPasswordValid(password));

            string conPass = null;
            do
            {
                try
                {

                    Console.Write("Insert password again : ");
                    conPass = Console.ReadLine();
                    if (conPass == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch
                {
                    isExceptionValid = true;
                    Console.WriteLine("Conifrm pass null exception");
                }

            } while (isExceptionValid || !UserValidation.IsPasswordSame(password, conPass));


            return password;
        }
    }
}
