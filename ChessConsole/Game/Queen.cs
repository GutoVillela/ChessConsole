using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Queen piece.
    /// [PT] Representa uma peça de Dama.
    /// </summary>
    public class Queen : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Queen.
        /// [PT] Cria uma nova instância da classe Queen.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        public Queen(PieceColor color) : base(color)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "D";
        }

        public override bool[,] PossibleMoves(ChessBoard board)
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}
