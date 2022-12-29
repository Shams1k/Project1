using DAL.Interfaces;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GameDal : IGameDal
    {
        private List<Game> games = new List<Game>()
        {
            //new Users() { Id = 1, Name = "Ivan", Age = 20, Phone = "123454" },
            //new Users() { Id = 2, Name = "Ivan", Age = 20, Phone = "123454" },
            //new Users() { Id = 3, Name = "Ivan", Age = 20, Phone = "123454" },
            //new Users() { Id = 4, Name = "Ivan"},
        };

        public Game GetById(int id)
        {
            return games.FirstOrDefault(item => item.Id == id);
        }

        public Game GetbyUserId(int UserId)
        {
            return games.FirstOrDefault(item => item.UserId == UserId);
        }

        public void PutGame(Game game)
        {
            games.Add(game);
        }
    }
}
