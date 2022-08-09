using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Common;

namespace UserManagementFinal.Database.Models
{
    class Comments : Entity<int>
    {
        public Blog Blog { get; set; }
        private static int _rowNumber;
        public int RowNumber { get; set; }
        public User From { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public Comments(Blog blog,User from,string content)
        {
            Blog = blog;
            RowNumber = _rowNumber;
            From = from;
            Content = content;
            CreatedTime = DateTime.Now;
            _rowNumber++;
        }

        public string GetInfo()
        {
            return RowNumber + " " +CreatedTime.ToString("mm,dd,yyyy") + " " + From.Name + " " + From.LastName + " " + Content;
        }
    }
}
