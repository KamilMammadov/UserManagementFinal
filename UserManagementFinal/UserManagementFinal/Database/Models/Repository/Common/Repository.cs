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
        protected static List<T> DBontens { get; set; } = new List<T>();
      

        public T Add(T entry)
        {
            DBontens.Add(entry);
            return entry;
        }

        public void Delete(T entry)
        {
            DBontens.Remove(entry);
        }

        public List<T> GetAll()
        {
            return DBontens;
        }

        public T GetById(TId id)
        {
            foreach (T entry in DBontens)
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
            foreach (T entry in DBontens)
            {
                if (expression(entry))
                {
                    return entry;
                }
            }
            return null;
        }
        //public T Update(TId id, string FirstName,string LastName)
        //{
        //    //User user = GetById(id);
        //    //user.Name = FirstName;
        //    //user.LastName = LastName;
        //    //user.UpdatedAt = DateTime.Now;

        //    //return user;

        //}
    }
}
