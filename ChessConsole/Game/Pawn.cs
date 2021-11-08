using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Pawn piece.
    /// [PT] Representa uma peça de Peão.
    /// </summary>
    public class Pawn : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Pawn.
        /// [PT] Cria uma nova instância da classe Pawn.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        public Pawn(PieceColor color) : base(color)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "P";
        }
        #endregion Methods
    }
}
