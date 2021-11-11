using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Bishop piece.
    /// [PT] Representa uma peça de Bispo.
    /// </summary>
    public class Bishop : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Bishop.
        /// [PT] Cria uma nova instância da classe Bishop.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        public Bishop(PieceColor color) : base(color)
        {

        }

        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves(ChessBoard board)
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}
