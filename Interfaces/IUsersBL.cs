using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsersBL
    {
        Users GetById(int id);
        Users GetByLogin(string login);
        void PutUser(Users user);

    }
}
