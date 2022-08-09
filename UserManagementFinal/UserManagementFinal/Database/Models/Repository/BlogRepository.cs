using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Repository.Common;

namespace UserManagementFinal.Database.Models.Repository
{
     class BlogRepository : Repository<Blog,string>
    {
        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                _code = "BL" + randomID.Next();
                return _code;
            }

        }
    }
}
