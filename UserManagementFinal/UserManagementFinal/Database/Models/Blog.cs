using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Enums;
using UserManagementFinal.Database.Models.Common;
using UserManagementFinal.Database.Models.Repository;

namespace UserManagementFinal.Database.Models
{
    class Blog: Entity<string>
    {
        public User From { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }
        public DateTime CreadetTime { get; set; }
        public BlogStatus Status { get; set; }


        public Blog(User from,string tittle,string content,BlogStatus status,string id=null)
        {
            From = from;
            Tittle = tittle;
            Content = content;
            Status = status;
            
            CreadetTime = DateTime.Now;
            if (id!=null)
            {
                ID = id;
            }
            else
            {
                ID = BlogRepository.RandomCode;
            }

        }

    }
}
