using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Enums;
using UserManagementFinal.Database.Models;
using UserManagementFinal.Database.Models.Repository;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.ApplicationLogic.Services
{
    partial class BlogService
    {
        private static BlogRepository blogrepo = new BlogRepository();
        private static CommentRepository commentrepo = new CommentRepository();

        public static void ShowBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll();
            List<Comments> comments = commentrepo.GetAll();
            foreach (Blog blog in blogs)
            {
                if (blog.Status == BlogStatus.Accepted)
                {
                    Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.Name}]  [{blog.From.LastName}] ");
                    Console.WriteLine($"==={blog.Tittle}===");
                    Console.WriteLine(blog.Content);
                    Console.WriteLine();

                    Console.WriteLine("Comments: " + comments.Count);
                    foreach (Comments comment in comments)
                    {
                        if (comment.Blog == blog)
                        {
                            Console.WriteLine($"{comment.GetInfo()}");
                        }
                    }
                }


            }
        }

        public static void FilteredBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll();
            List<Comments> comments = commentrepo.GetAll();
            Console.WriteLine("/tittle");
            Console.WriteLine("/firstname");
            Console.WriteLine("enter command");
            string command = Console.ReadLine();
            if (command == "/tittle")
            {
                Console.WriteLine("enter tittle :");
                string tittle = Console.ReadLine();

                foreach (Blog blog in blogs)
                {
                    if (blog.Tittle.Contains(tittle))
                    {
                        if (blog.Status == BlogStatus.Accepted)
                        {
                            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.Name}]  [{blog.From.LastName}] ");
                            Console.WriteLine($"==={blog.Tittle}===");
                            Console.WriteLine(blog.Content);
                            Console.WriteLine();

                            Console.WriteLine("Comments: " + comments.Count);
                            foreach (Comments comment in comments)
                            {
                                if (comment.Blog == blog)
                                {
                                    Console.WriteLine($"{comment.GetInfo()}");
                                }
                            }
                        }
                    }
                }

            }
            else if (command == "/firstname")
            {
                Console.WriteLine("enter firstname");
                string firstname = Console.ReadLine();
                foreach (Blog blog in blogs)
                {
                    if (blog.From.Name==firstname)
                    {
                        if (blog.Status == BlogStatus.Accepted)
                        {
                            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.Name}]  [{blog.From.LastName}] ");
                            Console.WriteLine($"==={blog.Tittle}===");
                            Console.WriteLine(blog.Content);
                            Console.WriteLine();

                            Console.WriteLine("Comments: " + comments.Count);
                            foreach (Comments comment in comments)
                            {
                                if (comment.Blog == blog)
                                {
                                    Console.WriteLine($"{comment.GetInfo()}");
                                }
                            }
                        }
                    }
                }
            }

        }

        public static void FindBlogByCode()
        {
            
            List<Comments> comments = commentrepo.GetAll();
            Console.WriteLine("Please enter code");
            string code = Console.ReadLine();

            Blog blog = BlogRepository.GetByCode(code);
            if (blog!=null)
            {
                Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.Name}]  [{blog.From.LastName}] ");
                Console.WriteLine($"==={blog.Tittle}===");
                Console.WriteLine(blog.Content);
                Console.WriteLine();

                Console.WriteLine("Comments: " + comments.Count);
                foreach (Comments comment in comments)
                {
                    if (comment.Blog == blog)
                    {
                        Console.WriteLine($"{comment.GetInfo()}");
                    }
                }
            }
        }

    }

    partial class BlogService
    {
        public static void Inbox()
        {
            List<Blog> blogs = blogrepo.GetAll();
            foreach (Blog blog in blogs)
            {
                if (blog.From.Id==Dashboard.CurrentUser.Id)
                {
                    switch (blog.Status)
                    {
                        case BlogStatus.Accepted:
                            Console.WriteLine($"Your {blog.ID} blog Accepted");
                            break;
                        case BlogStatus.Rejected:
                            Console.WriteLine($"Your {blog.ID} blog Rejected");
                            break;                      
                        default:
                            break;
                    }
                    Console.WriteLine();

                    List<Comments> comments = CommentRepository.GetCommentsByBlog(blog);
                    if (comments!=null)
                    {
                        foreach (Comments comment in comments)
                        {
                            Console.WriteLine($"{comment.From.Name} {comment.From.LastName} commented to your {blog.ID} blog ");
                        }
                    }
                }
            }
        }


    }
}
