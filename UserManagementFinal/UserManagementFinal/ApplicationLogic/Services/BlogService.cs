using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.ApplicationLogic.Validations;
using UserManagementFinal.Database.Enums;
using UserManagementFinal.Database.Models;
using UserManagementFinal.Database.Models.Repository;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.ApplicationLogic.Services
{
    partial class BlogService  //when program starts
    {
        private static BlogRepository blogrepo = new BlogRepository();
        private static CommentRepository commentrepo = new CommentRepository();
        private static InboxRepository inboxRepo = new InboxRepository();

        public static void ShowBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll(x => x.Status==BlogStatus.Accepted);         
            foreach (Blog blog in blogs)
            {               
                    PrintBlogDetail(blog);               
            }
        }

        public static void FilteredBlogs()
        {
            Console.WriteLine("/tittle");
            Console.WriteLine("/firstname");
            Console.WriteLine("enter command");
            string command = Console.ReadLine();

           

            if (command == "/tittle")
            {
                Console.WriteLine("enter tittle :");
                string tittle = Console.ReadLine();

                foreach (Blog blog in blogrepo.GetAll(x => x.Tittle.Contains(tittle)&& x.Status == BlogStatus.Accepted))
                {
                            PrintBlogDetail(blog);  
                }

            }
            else if (command == "/firstname")
            {
                Console.WriteLine("enter firstname");
                string firstname = Console.ReadLine();
                foreach (Blog blog in blogrepo.GetAll(x=> x.From.Name == firstname && x.Status == BlogStatus.Accepted))
                {
                            PrintBlogDetail(blog);
                }
            }

        }

        public static void FindBlogByCode()
        {    
            Console.WriteLine("Please enter code");
            string code = Console.ReadLine();

            Blog blog = BlogRepository.GetByCode(code);
            if (blog!=null)
            {
                PrintBlogDetail(blog);
            }
        }

        private static void PrintBlogDetail(Blog blog)
        {
            Console.WriteLine($"[{blog.CreadetTime.ToString("dd.MM.yyyy")}] [{blog.ID}] [{blog.From.Name}]  [{blog.From.LastName}] ");
            Console.WriteLine($"==={blog.Tittle}===");
            Console.WriteLine(blog.Content);
            Console.WriteLine();

                 

            int rowNumber = 1;
            foreach (Comments comment in commentrepo.GetAll(x=>x.Blog.ID==blog.ID ))
            {             
                    Console.WriteLine($"{rowNumber}. {comment.GetInfo()}");
                    rowNumber++;              
            }
            Console.WriteLine();

        }
    }

    partial class BlogService  //user`s methods
    {
        public static void Inbox()
        {
            List<Inbox> inboxes = inboxRepo.GetAll();
            if (inboxes!=null)
            {
                foreach (Inbox inbox in inboxes)
                {
                    if (inbox.To == Dashboard.CurrentUser)
                    {
                        Console.WriteLine(inbox.Message);

                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("----------Empty--------");
            }
        }

        public static void MyBlogs()
        {
         
            int rownumber = 1;
            foreach (Blog blog in blogrepo.GetAll(x=>x.From.Id==Dashboard.CurrentUser.Id))
            {         
                    Console.WriteLine($"{rownumber} {blog.GetInfo()}");
                    rownumber++;             
            }
        }

        public static void AddBlog()
        {
            Console.WriteLine("Enter Tittle of blog :");
            string tittle = Console.ReadLine();
            while (!BaseValidation.IsLengthCorrect(tittle,10,35))
            {
                Console.WriteLine("Tittle's length must be min 10,max 35");
                tittle = Console.ReadLine();
            }

            Console.WriteLine("enter blog content");
            string content = Console.ReadLine();
            while (!BaseValidation.IsLengthCorrect(content, 20, 45))
            {
                Console.WriteLine("Content's length must be min 20,max 45");
                content = Console.ReadLine();
            }

            BlogRepository.Add(Dashboard.CurrentUser, tittle, content);
        }

        public static void DeleteBlog()
        {
            Console.WriteLine("enter blog code :");
            string code = Console.ReadLine();

            Blog blog = BlogRepository.GetByCode(code);

            if (Dashboard.CurrentUser.Id==blog.From.Id)
            {
                blogrepo.Delete(blog);
                Console.WriteLine("your blog deleted succesfully.");
            }
            else
            {
                Console.WriteLine("You can remove only your blogs");
            }
        }
        
        public static void AddComment()
        {
            Console.WriteLine("Please enter blog's code which you want to comment");
            string code = Console.ReadLine();
            Blog blog = BlogRepository.GetByCode(code);
            if (blog!=null)
            {
            Console.WriteLine("enter your comment");
                string comment = Console.ReadLine();
                while (!BaseValidation.IsLengthCorrect(comment,10,35))
                {
                    Console.WriteLine("Comment's length must be min 10,max 35");
                    comment = Console.ReadLine();
                }
                
                //Inbox inbox = new Inbox(Dashboard.CurrentUser, blog, comment);
                //List<Inbox> inboxes = inboxRepo.GetAll();
                //inboxes.Add(inbox);

                Inbox inbox = new Inbox(blog.From, $"{blog.ID} blog Commented by {blog.From.Name} {blog.From.LastName}");
                inboxRepo.Add(inbox);

                CommentRepository.Add(blog, Dashboard.CurrentUser, comment);

                Console.WriteLine("Comment succesfully added");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Blog not found");
                Console.WriteLine();
            }
        }

    }


    partial class BlogService  //Admin`s methods
    {
        public static void BlogManagement()
        {
          
            foreach (Blog blog in blogrepo.GetAll(x=> x.Status==BlogStatus.Waiting))
            {
                PrintBlogDetail(blog);
            }

            Console.WriteLine("Commands :");
            Console.WriteLine("/approve-blog");
            Console.WriteLine("/reject-blog");
            string command = Console.ReadLine();

            Console.WriteLine("Enter blog's code :");
            string code = Console.ReadLine();
            Blog auditingBlog = BlogRepository.GetByCode(code);
            string message = null;
           
            if (auditingBlog!=null)
            {
                if (command == "/approve-blog")
                {
                    auditingBlog.Status = BlogStatus.Accepted;
                    message = $"{auditingBlog.ID}Blog Approved";

                    Inbox inbox = new Inbox(auditingBlog.From ,message);
                    inboxRepo.Add(inbox);

                    Console.WriteLine(message);
                    Console.WriteLine();
                }
                else if(command == "/reject-blog")
                {
                    auditingBlog.Status = BlogStatus.Rejected;
                    message = $"{auditingBlog.ID} Blog Rejected";

                    Inbox inbox = new Inbox(auditingBlog.From,  message);
                    inboxRepo.Add(inbox);
                    Console.WriteLine(message);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("command not found");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Blog not found");
            }
        }
    }
}
