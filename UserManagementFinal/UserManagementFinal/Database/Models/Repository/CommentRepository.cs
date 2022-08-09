using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.Database.Models.Repository
{
    class CommentRepository : Repository<Comments,int>
    {
        static CommentRepository()
        {
            Blog blog = BlogRepository.GetByCode("BL001");
            User user = Repository<User, int>.GetById(1);
            User user1 = Repository<User, int>.GetById(2);
            User user2 = Repository<User, int>.GetById(3);
            
            DBContens.Add(new Comments(blog,user,"It is perfect!!!!!!!!"));
            DBContens.Add(new Comments(blog, user1, "It is perfect!!!!!!!!"));
            DBContens.Add(new Comments(blog, user2, "It is perfect!!!!!!!!"));
            DBContens.Add(new Comments(blog, user2, "It is perfect!!!!!!!!"));
        }

        public static Comments Add(Blog blog,User from,string text)
        {
            Comments comments = new Comments(blog,from,text);
            DBContens.Add(comments);
            return comments;           
        }

    }
}
