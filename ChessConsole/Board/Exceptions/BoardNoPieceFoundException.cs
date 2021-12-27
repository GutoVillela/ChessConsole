using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Board.Exceptions
{
    internal class BoardNoPieceFoundException : BoardException
    {
        /// <summary>
        /// [EN] Creates a new instance of the class BoardNoPieceFoundException.
        /// [PT] Cria uma nova instância da classe BoardNoPieceFoundException.
        /// </summary>
        /// <param name="message">[EN] Error message. [PT] Mensagem de erro.</param>
        public BoardNoPieceFoundException(string message) : base(message)
        {

        }
    }
}
