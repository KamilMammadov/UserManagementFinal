using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementFinal.Database.Models.Common
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
