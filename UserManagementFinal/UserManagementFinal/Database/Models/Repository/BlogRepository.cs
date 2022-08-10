using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Enums;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.Database.Models.Repository
{
     class BlogRepository : Repository<Blog,string>
    {
        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                _code = "BL" + randomID.Next();
                return _code;
            }

        }


       static BlogRepository()
        {
            User user = Repository<User,int>.GetById(2);
            User user1 = Repository<User, int>.GetById(1);

            DBContens.Add(new Blog(user, "How to learn programming", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.\n" +
                " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,\n when an unknown printer took a galley of type and" +
                " scrambled it to make a type specimen book.\n It has survived not only five centuries", BlogStatus.Accepted, "BL001"));


            DBContens.Add(new Blog(user1, "How to learn programming", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.\n" +
             " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,\n when an unknown printer took a galley of type and" +
             " scrambled it to make a type specimen book.\n It has survived not only five centuries", BlogStatus.Accepted, "BL002"));

           

        }

        public static Blog Add(User from ,string tittle,string text)
        {
            Blog blog = new Blog(from, tittle, text,BlogStatus.Waiting);
            DBContens.Add(blog);
            return blog;
        }
       

        public static Blog GetByCode(string code)
        {
            List<Blog> blogs= new List<Blog>();

            foreach (Blog blog in DBContens)
            {
                if (blog.ID==code)
                {
                    return blog;
                }
            }
            return null;
        }
       
    }
}
