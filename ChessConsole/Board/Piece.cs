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

        #region Methods
        /// <summary>
        /// [EN] Gives all the possible moves of the current piece.
        /// [PT] Fornece todos os movimentos possíveis da peça atual.
        /// </summary>
        /// <param name="color">[EN] Current chess board. [PT] Tabuleiro de xadrez atual.</param>
        /// <returns>
        /// [EN] Matrix that represents the current board, where every true position is a possible move and every false position is an illegal move.
        /// [PT] Matriz que representa o tabuleiro atual, onde cada posição verdadeira é um movimento possível e cada posição falsa é um movimento ilegal
        /// </returns>
        public abstract bool[,] PossibleMoves(ChessBoard board);

        /// <summary>
        /// [EN] Checks if the movement is allowed to the given position.
        /// [PT] Verifica se o movimento da peça atual é permitido para a posição dada.
        /// </summary>
        /// <param name="board">[EN] Current board. [PT] Tabuleiro atual.</param>
        /// <param name="position">[EN] Position to move. [PT] Posição a mover peça.</param>
        /// <returns></returns>
        protected bool IsMoveAllowed(ChessBoard board, Position position)
        {
            if (!board.ExistsPiece(position))
                return true;

            return board.GetPiece(position).Color != Color;
        }
        #endregion Methods
    }
}
