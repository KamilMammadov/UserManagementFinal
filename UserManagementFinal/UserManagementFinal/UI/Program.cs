using System;
using UserManagementFinal.ApplicationLogic;

namespace UserManagementFinal
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/exit");
            Console.WriteLine(" enter command : ");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter suitable command :");
                string command = Console.ReadLine();
                if (command == "/register")
                {
                    Authentication.Register();

                }
                else if (command == "/login")
                {

                    Authentication.Login();

                }
                else if (command =="/show-blogs-with-comments")
                {

                }
                else if (command == "/exit")
                {

                    break;
                }
                else
                {
                    Console.WriteLine("Command not found ...");
                }
            }
        }
    }
}
