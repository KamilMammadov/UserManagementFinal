﻿using System;
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

    }

    partial class BlogService
    {



    }
}
