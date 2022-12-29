using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IGameDal
    {
        Game GetbyUserId(int UserId);
        void PutGame(Game game);
    }
}
