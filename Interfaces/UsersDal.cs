using Entities;
using System;

namespace Interfaces
{
    public interface IUsersDal
    {
        Users GetById(int id);
        Users GetByLogin(string login);
        void PutUser(Users user);
    }
}
