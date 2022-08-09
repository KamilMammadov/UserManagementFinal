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
        public CommentRepository()
        {
            
        }

        public static Comments Add(Blog blog,User from,string text)
        {
            Comments comments = new Comments(blog,from,text);
            DBContens.Add(comments);
            return comments;           
        }

    }
}
