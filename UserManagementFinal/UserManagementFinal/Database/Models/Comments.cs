using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Common;

namespace UserManagementFinal.Database.Models
{
    public class Comments : Entity<int>
    {
        public Blog Blog { get; set; }
       
        public User From { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public Comments(Blog blog,User from,string content)
        {
            Blog = blog;
        
            From = from;
            Content = content;
            CreatedTime = DateTime.Now;
        
        }

        public string GetInfo()
        {
            return CreatedTime.ToString("mm.dd.yyyy") + " " + From.Name + " " + From.LastName + " " + Content;
        }
    }
}
