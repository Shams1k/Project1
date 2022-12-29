using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UsersDal : IUsersDal
    {
        private static List<Users> users = new List<Users>()
        {
            new Users() {Login = "a", Password = "a", Name="a", CreationDate = DateTime.Now, Id=0},
        };

        public Users GetById(int id)
        {
            return users.FirstOrDefault(item => item.Id == id);
        }
        public Users GetByLogin(string login)
        {
            return users.FirstOrDefault(item => item.Login == login);
        }

        public void PutUser(Users user)
        {
            users.Add(user);
        }
    }
}
