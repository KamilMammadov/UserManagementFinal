using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementFinal.Database.Models
{
    class InboxRepository : Repository.Common.Repository<Inbox,int>
    {
        public static Inbox Add(User to,string message)
        {
            Inbox inbox = new Inbox(to,message);
            DBContens.Add(inbox);
            return inbox;
        }
        
      
    }
}
