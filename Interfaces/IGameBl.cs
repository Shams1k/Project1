using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IGameBl
    {
        Game GetbyUserId(int UserId);
        void PutGame(Game game);
    }
}
