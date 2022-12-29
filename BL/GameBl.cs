using BL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class GameBl : IGameBl
    {
        private readonly IGameDal _dal;

        public GameBl(IGameDal dal)
        {
            _dal = dal;
        }
        public Game GetbyUserId(int UserId)
        {
            return _dal.GetbyUserId(UserId);
        }

        public void PutGame(Game game)
        {
            _dal.PutGame(game);
        }
    }
}
