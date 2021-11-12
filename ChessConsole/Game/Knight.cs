using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Knight piece.
    /// [PT] Representa uma peça de Cavalo.
    /// </summary>
    public class Knight : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Knight.
        /// [PT] Cria uma nova instância da classe Knight.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] Tabuleiro associado à peça.</param>
        public Knight(Color color, ChessBoard board) : base(color, board)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "C";
        }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}
