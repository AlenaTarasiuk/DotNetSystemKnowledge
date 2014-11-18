using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSystemKnowledge.Domain.Interfaces;
using DotNetSystemKnowledge.Domain.Entities;

namespace DotNetSystemKnowledge.Domain.Concrete
{
    public class UserDbRepository : IUserRepository
    {
        private UserDb context = new UserDb();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public bool CreateOfChangeUser(User user)
        {
            if (user.UserId == 0) 
                context.Users.Add(user);
            else
            {
                User dbUser = context.Users.Find(user.UserId);
                if (dbUser != null)
                {
                    dbUser.Name = user.Name;
                    dbUser.Password = user.Password;
                    dbUser.Email = user.Email;
                }
            }

            context.SaveChanges();
            return false;
        }

        public bool CheckExistenceOfUser(string userName)
        {
            IQueryable<User> list = context.Users.AsQueryable<User>().Where(m => m.Name.Equals(userName));
            List<User> users = list.ToList<User>();
            return users.Count == 0 ? false : true;
        }

        public bool AuthenticationOfUser(string userNameorEmail, string userPassword)
        {
            int hash = userPassword.GetHashCode();
            var user = from u in context.Users where u.Name == userNameorEmail && u.Password == hash.ToString() select u;
          //  List<User> users = user.ToList<User>();

          //  return users.Count == 0 ? false : true;
            return true;
        }
    }
}
