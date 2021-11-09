using System;

namespace ChessConsole.Board.Exceptions
{
    /// <summary>
    /// [EN] Board Exceptions.
    /// [PT] Exceções do tabuleiro.
    /// </summary>
    internal class BoardException : ApplicationException
    {
        /// <summary>
        /// [EN] Creates a new instance of the class BoardException.
        /// [PT] Cria uma nova instância da classe BoardException.
        /// </summary>
        /// <param name="message">[EN] Error message. [PT] Mensagem de erro.</param>
        public BoardException(string message) : base(message)
        {

        }
    }
}
