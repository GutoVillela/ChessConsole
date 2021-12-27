using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Game.Exceptions
{
    internal class CastleNotAllowedException : GameException
    {
        public CastleNotAllowedException(string message) : base(message)
        {

        }
    }
}
