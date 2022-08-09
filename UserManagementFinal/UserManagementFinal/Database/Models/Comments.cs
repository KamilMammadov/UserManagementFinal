using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementFinal.Database.Models
{
    class Comments
    {
        private static int _rowNumber;
        public int RowNumber { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

        public Comments(string content)
        {
            RowNumber = _rowNumber;
            Content = content;
            CreatedTime = DateTime.Now;
            _rowNumber++;
        }


    }
}
