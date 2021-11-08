using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    /// <summary>
    /// [EN] Represents the chess board.
    /// [PT] Representa o tabuleiro de xadrez.
    /// </summary>
    public class ChessBoard
    {
        #region Constants
        /// <summary>
        /// [EN] Number of lines on the board.
        /// [PT] Número de linhas do tabuleiro.
        /// </summary>
        private const int ROWS = 8;

        /// <summary>
        /// [EN] Number of columns on the board.
        /// [PT] Número de colunas do tabuleiro.
        /// </summary>
        private const int COLUMNS = 8;
        #endregion Constants

        #region Properties
        /// <summary>
        /// [EN] Pieces positioned on the board.
        /// [PT] Peças posicionadas no tabuleiro.
        /// </summary>
        public Piece[,] Pieces { get; private set; } = new Piece[ROWS, COLUMNS];

        #endregion Properties
    }
}
