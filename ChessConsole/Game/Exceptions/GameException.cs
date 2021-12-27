using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Game.Exceptions
{
    internal class GameException : ApplicationException
    {
        public GameException(string message) : base(message)
        {

        }
    }
}
