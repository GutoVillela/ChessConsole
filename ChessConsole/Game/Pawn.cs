using ChessConsole.Board;
using ChessConsole.Board.Enums;
using ChessConsole.Board.Exceptions;
using ChessConsole.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Pawn piece.
    /// [PT] Representa uma peça de Peão.
    /// </summary>
    public class Pawn : Piece, ICountableMovePiece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Pawn.
        /// [PT] Cria uma nova instância da classe Pawn.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] Tabuleiro associado à peça.</param>
        public Pawn(Color color, ChessBoard board) : base(color, board)
        {

        }
        #endregion Constructor

        #region Properties
        public ushort MovesPerformed { get; set; }
        #endregion Properties

        #region Methods
        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[ChessBoard.ROWS, ChessBoard.COLUMNS];
            Position position;

            #region White
            if(Color == Color.White)
            {
                if (Position.Row > 0)
                {
                    position = new(Convert.ToByte(Position.Row - 1),Position.Column);
                    if (Board.CheckPosition(position) && IsPositionEmpty(position))
                        possibleMoves[position.Row, position.Column] = true;
                }

                if (Position.Row > 1)
                {
                    position = new(Convert.ToByte(Position.Row - 2), Position.Column);
                    if (Board.CheckPosition(position) && IsPositionEmpty(position) && MovesPerformed == 0)
                        possibleMoves[position.Row, position.Column] = true;
                }

                if (Position.Row > 0 && Position.Column > 0)
                {
                    position = new(Convert.ToByte(Position.Row - 1), Convert.ToByte(Position.Column - 1));
                    if (Board.CheckPosition(position) && IsAnyEnemyOnGivenPosition(position))
                        possibleMoves[position.Row, position.Column] = true;
                }

                if (Position.Row > 0)
                {
                    position = new(Convert.ToByte(Position.Row - 1), Convert.ToByte(Position.Column + 1));
                    if (Board.CheckPosition(position) && IsAnyEnemyOnGivenPosition(position))
                        possibleMoves[position.Row, position.Column] = true;
                }
            }
            #endregion White

            #region Black
            if (Color == Color.Black)
            {
                position = new(Convert.ToByte(Position.Row + 1), Position.Column);
                if (Board.CheckPosition(position) && IsPositionEmpty(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new(Convert.ToByte(Position.Row + 2), Position.Column);
                if (Board.CheckPosition(position) && IsPositionEmpty(position) && MovesPerformed == 0)
                    possibleMoves[position.Row, position.Column] = true;

                if (Position.Column > 0)
                {
                    position = new(Convert.ToByte(Position.Row + 1), Convert.ToByte(Position.Column - 1));
                    if (Board.CheckPosition(position) && IsAnyEnemyOnGivenPosition(position))
                        possibleMoves[position.Row, position.Column] = true;
                }

                position = new(Convert.ToByte(Position.Row -+ 1), Convert.ToByte(Position.Column + 1));
                if (Board.CheckPosition(position) && IsAnyEnemyOnGivenPosition(position))
                    possibleMoves[position.Row, position.Column] = true;
            }
            #endregion Black

            return possibleMoves;
        }

        /// <summary>
        /// [EN] Checks if there's an enemy on the given position.
        /// [PT] Verifica se existe algum inimigo na posição dada.
        /// </summary>
        /// <param name="position">[EN] Position to verify. [PT] Posição a verificar.</param>
        /// <returns></returns>
        private bool IsAnyEnemyOnGivenPosition(Position position)
        {
            try
            {
                Piece piece = Board.GetPiece(position);
                return piece != null && piece.Color != Color;
            }
            catch (BoardNoPieceFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// [EN] Checks if the given position is Empty.
        /// [PT] Verifica se posição fornecida está vazia.
        /// </summary>
        /// <param name="position">[EN] Position to verify. [PT] Posição a verificar.</param>
        /// <returns></returns>
        private bool IsPositionEmpty(Position position)
        {
            return !Board.ExistsPiece(position);
        }

        public bool Moved()
        {
            return MovesPerformed > 0;
        }
        #endregion Methods
    }
}
