using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a King piece.
    /// [PT] Representa uma peça de Rei.
    /// </summary>
    public class King : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class King.
        /// [PT] Cria uma nova instância da classe King.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        public King(PieceColor color) : base(color)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "R";
        }
        #endregion Methods
    }
}