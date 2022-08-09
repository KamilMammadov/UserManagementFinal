using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementFinal.Database.Models
{
    class Blog
    {
        public string Tittle { get; set; }
        public string Content { get; set; }
        public int ID { get; set; }
        public DateTime CreadetTime { get; set; }
        public List<Comments> Comments { get; set; }

        public Blog(string tittle,string content,List<Comments> comments)
        {
            Tittle = tittle;
            Content = content;
            Comments = comments;

        }

    }
}
