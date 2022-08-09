using System;
using UserManagementFinal.ApplicationLogic;
using UserManagementFinal.ApplicationLogic.Services;
using UserManagementFinal.Database.Models.Repository;

namespace UserManagementFinal
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/show-blogs-with-comments");
            Console.WriteLine("/show-filtered-blogs-with-comments");
            Console.WriteLine("/find-blog-by-code");
            Console.WriteLine("/exit");

            Console.WriteLine();
            
            while (true)
            {
                UserRepository userRepository = new UserRepository();
                CommentRepository commentRepository = new CommentRepository();
                Console.Write("Enter command :");
                string command = Console.ReadLine();
                if (command == "/register")
                {
                    Authentication.Register();

                }
                else if (command == "/login")
                {

                    Authentication.Login();

                }
                else if (command == "/show-blogs-with-comments")
                {
                    BlogService.ShowBlogs();
                }
                else if (command == "/show-filtered-blogs-with-comments")
                {
                    BlogService.FilteredBlogs();
                }
                else if (command == "/find-blog-by-code")
                {
                    BlogService.FindBlogByCode();

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
