using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementFinal.Database.Models.Common;

namespace UserManagementFinal.Database.Models.Repository.Common
{
    public class Repository<T, TId>
         where T : Entity<TId>
    {
        protected static List<T> Entries { get; set; } = new List<T>()
        {


        };

        public T Add(T entry)
        {
            Entries.Add(entry);
            return entry;
        }

        public void Delete(T entry)
        {
            Entries.Remove(entry);
        }

        public List<T> GetAll()
        {
            return Entries;
        }

        public T GetById(TId id)
        {
            foreach (T entry in Entries)
            {

                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }
            return default(T);
        }

        public T Get(Predicate<T> expression)
        {
            foreach (T entry in Entries)
            {
                if (expression(entry))
                {
                    return entry;
                }
            }
            return null;
        }
        public T Update(TId id, string FirstName,string LastName)
        {
            User user = GetById(id);
            user.Name = FirstName;
            user.LastName = LastName;
            user.UpdatedAt = DateTime.Now;

            return user;

        }
    }
}
