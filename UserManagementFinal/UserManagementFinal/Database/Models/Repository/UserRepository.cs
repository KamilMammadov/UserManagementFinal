using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementFinal.Database.Models.Repository
{
    class UserRepository : Common.Repository<User, int>
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }

        }

        static UserRepository()
        {
            SeedUsers();
        }

        public static void SeedUsers()
        {
            DBContens.Add(new User("kamil", "mammadov", "kamil@gmail.com", "123321"));
            DBContens.Add(new Admin("Mahmood", "Garibov", "Garibov@gmail.com", "123321"));
            DBContens.Add(new User("eshqin", "ferecov", "eshqin@gmail.com", "123321"));
            DBContens.Add(new Admin("Revan", "Maxmudov", "revan@gmail.com", "123321"));
            DBContens.Add(new User("kamil", "ferecov", "kamilmammadov@code.edu.az", "123321"));


        }


        //normal user elave etmek.
        public static User AddUser(string name, string lastName, string email, string password)
        {

            User user = new User(name, lastName, email, password,IdCounter);
            DBContens.Add(user);
            return user;
        }

        //admin silinenden sonra user kimi liste elave edilmekdir.
        //public static User Add(string name, string lastName, string email, string password, int id)
        //{

        //    User user = new User(name, lastName, email, password, id);
        //    DBContens.Add(user);
        //    return user;
        //}



        //public static User Add(User user)
        //{
        //    Users.Add(user);
        //    return user;
        //}


        //public static User Add(Admin admin)
        //{
        //    Users.Add(admin);
        //    return admin;
        //}





        public static void Remove(string email)
        {
            foreach (User user1 in DBContens)
            {
                if (user1.Email == email)
                {
                    DBContens.Remove(user1);
                }
            }
        }
        //public static void Delete(User user)
        //{
        //    Users.Remove(user);
        //}
        //public static void DeleteAdmin(Admin admin)
        //{
        //    Users.Remove(admin);
        //}
        public static bool IsEmailExists(string email)
        {
            foreach (User user in DBContens)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public static User GetByEmail(string email)
        {
            foreach (User user in DBContens)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public static Admin GetByEmailForAdmin(string email)
        {
            foreach (Admin admin in DBContens)
            {
                if (admin.Email == email)
                {
                    return admin;
                }
            }
            return null;
        }

        public static bool IsUserExistsByEmailAndPassword(string email, string password)
        {
            foreach (User user in DBContens)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;

        }

        //public static List<User> GetAll()
        //{
        //    return Users;
        //}


        public static User UpdateForUser(string email, User user)
        {
            User findedUser = UserRepository.GetByEmail(email);

            findedUser.Name = user.Name;
            findedUser.LastName = user.LastName;


            return findedUser;
        }

        
    }
}
