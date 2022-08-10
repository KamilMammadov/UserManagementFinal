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
        
        public string Message { get; set; }
        public Inbox(User to, string message)
        {
            To = to;
          
            Message = message;
        }

        
    }
}
