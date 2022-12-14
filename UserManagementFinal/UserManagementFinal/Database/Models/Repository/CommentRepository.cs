using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.Database.Models.Repository
{
    public class CommentRepository : Repository<Comments,int>
    {
        public  CommentRepository()
        {
            Blog blog = BlogRepository.GetByCode("BL002");
            Blog blog1 = BlogRepository.GetByCode("BL001");

            User user = Repository<User, int>.GetById(1);
            User user1 = Repository<User, int>.GetById(2);
            User user2 = Repository<User, int>.GetById(3);
            
            DBContens.Add(new Comments(blog1,user,"It is perfect!!!!!!!!"));
            DBContens.Add(new Comments(blog1, user1, "good!"));
            DBContens.Add(new Comments(blog, user2, "HI!"));
            DBContens.Add(new Comments(blog, user2, "Not Bad"));
        }

        public static Comments Add(Blog blog,User from,string text)
        {
            Comments comments = new Comments(blog,from,text);
            DBContens.Add(comments);
            return comments;
        }

        
     
    }
}
