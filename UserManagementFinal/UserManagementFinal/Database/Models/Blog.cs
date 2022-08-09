using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Common;
using UserManagementFinal.Database.Models.Repository;

namespace UserManagementFinal.Database.Models
{
    class Blog: Entity<string>
    {
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }
        public DateTime CreadetTime { get; set; }
        public List<Comments> Comments { get; set; }

        public Blog(string tittle,string content,List<Comments> comments,string id=null)
        {
            Tittle = tittle;
            Content = content;
            Comments = comments;
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
