using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Rook piece.
    /// [PT] Representa uma peça de Torre.
    /// </summary>
    public class Rook : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Rook.
        /// [PT] Cria uma nova instância da classe Rook.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        public Rook(PieceColor color) : base(color)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "T";
        }
        #endregion Methods
    }
}
