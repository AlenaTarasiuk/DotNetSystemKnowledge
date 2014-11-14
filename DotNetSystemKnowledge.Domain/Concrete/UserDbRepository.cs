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
    }
}
