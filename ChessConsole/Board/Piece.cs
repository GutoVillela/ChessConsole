using ChessConsole.Board.Enums;
using ChessConsole.Board.Exceptions;
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
        public Color Color { get; set; }

        /// <summary>
        /// [EN] Piece position on the board.
        /// [PT] Posição da peça no tabuleiro
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// [EN] Board associated to the piece.
        /// [PT] Tabuleiro associado à peça.
        /// </summary>
        protected ChessBoard Board { get; set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Piece.
        /// [PT] Cria uma nova instância da classe Piece.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] abuleiro associado à peça.</param>
        public Piece(Color color, ChessBoard board)
        {
            Color = color;
            Board = board;
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
        public abstract bool[,] PossibleMoves();

        /// <summary>
        /// [EN] Checks if there is any possible move to the current Piece.
        /// [PT] Verifica se existe algum movimento possível para a peça atual.
        /// </summary>
        /// <returns>[EN] True if there is at least one possible move and false otherwise. [PT] True caso exista pelo menos um movimento possível e false caso contrário.</returns>
        public bool AnyPossibleMove()
        {
            bool[,] possibleMoves = PossibleMoves();            

            for (int i = 0; i < possibleMoves.GetLength(0); i++)
            {
                for (int j = 0; j < possibleMoves.GetLength(1); j++)
                {
                    if (possibleMoves[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// [EN] Checks if the given position is contained in the piece possible moves.
        /// [PT] Verifica se a posição fornecida está contida nas posições possíveis da peça.
        /// </summary>
        /// <param name="pos">[EN] Position to be validates. [PT] Posição para ser validada.</param>
        /// <returns>[EN] True if there the move is possible and false otherwise. [PT] True caso movimento seja possível e false caso contrário.</returns>
        public bool IsMovePossible(Position position)
        {
            bool [,] possibleMoves = PossibleMoves();
            if (position.Row > possibleMoves.GetLength(0) || position.Column > possibleMoves.GetLength(1))
                throw new BoardException("The given position doesn't exist on the board!");

            return possibleMoves[position.Row, position.Column];
        }

        /// <summary>
        /// [EN] Checks if the movement is allowed to the given position.
        /// [PT] Verifica se o movimento da peça atual é permitido para a posição dada.
        /// </summary>
        /// <param name="board">[EN] Current board. [PT] Tabuleiro atual.</param>
        /// <param name="position">[EN] Position to move. [PT] Posição a mover peça.</param>
        /// <returns></returns>
        protected bool IsMoveAllowed(Position position)
        {
            if (!Board.ExistsPiece(position))
                return true;

            return Board.GetPiece(position).Color != Color;
        }
        #endregion Methods
    }
}
