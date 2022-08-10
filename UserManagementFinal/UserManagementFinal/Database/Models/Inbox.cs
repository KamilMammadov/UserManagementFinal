using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Common;

namespace UserManagementFinal.Database.Models
{
    class Inbox : Entity<int>
    {
        public User To { get; set; }
        public Blog Blog { get; set; }
        public string Message { get; set; }
        public Inbox(User to, Blog blog, string message)
        {
            To = to;
            Blog = blog;
            Message = message;
        }

        public string GetMessage()
        {
            return Blog.ID + " " + Message;
        }
    }
}
