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
            User user = Repository.Common.Repository<User,int>.GetById(2);
            DBContens.Add(new Blog(user, "How to learn programming", "Lorem Ipsum is simply dummy text", BlogStatus.Accepted,"BL001"));           
        }

        public static Blog Add(User from ,string tittle,string text)
        {
            Blog blog = new Blog(from, tittle, text,BlogStatus.Waiting);
            DBContens.Add(blog);
            return blog;
        }
       
    }
}
