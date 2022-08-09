using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models;
using UserManagementFinal.Database.Models.Repository;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.ApplicationLogic.Services
{
    partial class BlogService
    {
        private static BlogRepository blogrepo = new BlogRepository();
       
        public static void ShowBlogs()
        {
            List<Blog> blogs = blogrepo.GetAll();

            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"[{blog.CreadetTime.ToString("dd,MM,yyyy")}]  [{blog.From.Name}]  [{blog.From.LastName}] ");
                Console.WriteLine($"==={blog.Tittle}===" );
                Console.WriteLine(blog.Content);
                Console.WriteLine();
            }
        }


    }

    partial class BlogService
    {



    }
}
