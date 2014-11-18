using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSystemKnowledge.Domain.Entities;

namespace DotNetSystemKnowledge.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        bool AuthenticationOfUser(string userName, string userPassword);
        bool CheckExistenceOfUser(string userName);
        bool CreateOfChangeUser(User user);
    }
}
