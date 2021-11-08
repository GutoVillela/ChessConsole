using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    /// <summary>
    /// [EN] Represents a chess piece.
    /// [PT] Representa uma peça de xadrez.
    /// </summary>
    public abstract class Piece
    {
        #region Properties
        /// <summary>
        /// [EN] Piece color.
        /// [PT] Cor da peça.
        /// </summary>
        public PieceColor Color { get; set; }

        /// <summary>
        /// [EN] Piece position on the board.
        /// [PT] Posição da peça no tabuleiro
        /// </summary>
        public Position Position { get; set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Piece.
        /// [PT] Cria uma nova instância da classe Piece.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        public Piece(PieceColor color)
        {
            Color = color;
        }
        #endregion Constructor
    }
}
