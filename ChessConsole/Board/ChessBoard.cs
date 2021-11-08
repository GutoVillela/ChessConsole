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

        #region Methods
        /// <summary>
        /// [EN] Places a piece on the board at the given position.
        /// [PT] Posiciona uma peça no tabuleiro na posição indicada.
        /// </summary>
        /// <param name="piece">[EN] Piece to be placed. [PT] Peça a ser posicionada.</param>
        /// <param name="piece">[EN] Position to place the piece. [PT] Posição a se colocar a peça.</param>
        public void PlacePiece(Piece piece, Position position)
        {
            if (position.Row >= Pieces.GetLength(0) || position.Column >= COLUMNS)
                throw new ArgumentOutOfRangeException($"The given position is out of the board range. Please provide a position between row {Pieces.GetLength(0) - 1} and column {Pieces.GetLength(1) - 1}.");

            piece.Position = position;
            Pieces[position.Row, position.Column] = piece;
        }
        #endregion Methods
    }
}