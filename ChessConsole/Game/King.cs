using ChessConsole.Board;
using ChessConsole.Board.Enums;
using ChessConsole.Game.Interfaces;
using System;
using ChessConsole.Game.Exceptions;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a King piece.
    /// [PT] Representa uma peça de Rei.
    /// </summary>
    public class King : Piece, ICountableMovePiece
    {
        #region Properties
        /// <summary>
        /// [EN] Indicates that the King is in check.
        /// [PT] Indica que o Rei está em xeque.
        /// </summary>
        public bool IsInCheck { get; set; }
        public ushort MovesPerformed { get; set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class King.
        /// [PT] Cria uma nova instância da classe King.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] Tabuleiro associado à peça.</param>
        public King(Color color, ChessBoard board) : base(color, board)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[ChessBoard.ROWS, ChessBoard.COLUMNS];
            Position position;

            // [EN] Check all positions adjacent to the King. [PT] Checar todas as posições adjacentes ao rei
            if(Position.Row > 0)
            {
                position = new Position(Convert.ToByte(Position.Row - 1), Position.Column);
                if(Board.CheckPosition(position) && IsMoveAllowed(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Convert.ToByte(Position.Row - 1), Convert.ToByte(Position.Column + 1));
                if (Board.CheckPosition(position) && IsMoveAllowed(position))
                    possibleMoves[position.Row, position.Column] = true;
            }
            
            position = new Position(Position.Row, Convert.ToByte(Position.Column + 1));
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            position = new Position(Convert.ToByte(Position.Row + 1), Convert.ToByte(Position.Column + 1));
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            if(Position.Column > 0)
            {
                position = new Position(Convert.ToByte(Position.Row + 1), Convert.ToByte(Position.Column - 1));
                if (Board.CheckPosition(position) && IsMoveAllowed(position))
                    possibleMoves[position.Row, position.Column] = true;

                position = new Position(Position.Row, Convert.ToByte(Position.Column - 1));
                if (Board.CheckPosition(position) && IsMoveAllowed(position))
                    possibleMoves[position.Row, position.Column] = true;

                if(Position.Row > 0)
                {
                    position = new Position(Convert.ToByte(Position.Row - 1), Convert.ToByte(Position.Column - 1));
                    if (Board.CheckPosition(position) && IsMoveAllowed(position))
                        possibleMoves[position.Row, position.Column] = true;
                }
            }

            #region Special moves

            // Castles
            if(MovesPerformed == 0 && !IsInCheck)
            {
                try
                {
                    // Castle
                    ValidadeCastle();
                    possibleMoves[Position.Row, Position.Column + 2] = true;
                }
                catch (GameException)
                {
                }

                try
                {
                    // Big Castle
                    ValidadeBigCastle();
                    possibleMoves[Position.Row, Position.Column - 2] = true;
                }
                catch (GameException)
                {
                }


            }
            #endregion Special moves

            return possibleMoves;
        }

        /// <summary>
        /// [EN] Validate if all the requirements were met to perform the Castle movement.
        /// [PT] Valida se todos os requisitos foram cumpridos para realizar o movimento de Roque pequeno.
        /// </summary>
        /// <exception cref="CastleNotAllowedException"></exception>
        private void ValidadeCastle()
        {
            try
            {
                ValidateRightRookForCastle();
                ValidateBoardForCastle();
            }
            catch (Exception e)
            {
                throw new CastleNotAllowedException(e.Message);
            }
        }

        /// <summary>
        /// [EN] Validate if the right rook meets the requirements for castle.
        /// [PT] Verifica se a torre da direita cumpre os requisitos para o roque pequeno.
        /// </summary>
        /// <exception cref="GameException"></exception>
        private void ValidateRightRookForCastle()
        {
            try
            {
                Piece rightTower = Board.GetPiece(new Position(Position.Row, Convert.ToByte(Position.Column + 3)));
                ValidadeRookForCastle(rightTower);
            }
            catch (Exception e)
            {
                throw new GameException(e.Message);
            }
        }

        /// <summary>
        /// [EN] Validate if the rook meets the basic requirements for castles in general.
        /// [PT] Verifica se a torre cumpre os requisitos básicos para o roque em geral.
        /// </summary>
        /// <param name="piece"></param>
        /// <exception cref="CastleNotAllowedException"></exception>
        private void ValidadeRookForCastle(Piece piece)
        {
            if (piece == null)
                throw new CastleNotAllowedException("It is not possible to castle because the rook is not on it's original position or it's been captured.");

            if (piece is not Rook)
                throw new CastleNotAllowedException("The piece placed on the rook position is not a rook.");

            if ((piece as Rook).Moved())
                throw new CastleNotAllowedException("The rook has already moved so the castle is not allowed.");

            if (piece.Color != Color)
                throw new CastleNotAllowedException($"This rook doesn't belong to the player {Color}.");

        }

        /// <summary>
        /// [EN] Checks if the board in the current position meets the requirements for castling.
        /// [PT] Verifica se o tabuleiro na posição atual cumpre os requisitos para o roque. 
        /// </summary>
        /// <exception cref="CastleNotAllowedException"></exception>
        private void ValidateBoardForCastle()
        {
            try
            {
                Position positionOneSquareNextToKing = new(Position.Row, Convert.ToByte(Position.Column + 1));
                Position positionTwoSquaresNextToKing = new(Position.Row, Convert.ToByte(Position.Column + 2));


                if (Board.ExistsPiece(positionOneSquareNextToKing) || Board.ExistsPiece(positionTwoSquaresNextToKing))
                    throw new CastleNotAllowedException("It's not possible to castle because the squares between the king and the right rook must be empty.");
            }
            catch(Exception e)
            {
                throw new CastleNotAllowedException(e.Message);
            }
        }

        /// <summary>
        /// [EN] Validate if all the requirements were met to perform the Big Castle movement.
        /// [PT] Valida se todos os requisitos foram cumpridos para realizar o movimento de Roque Grande.
        /// </summary>
        /// <exception cref="CastleNotAllowedException"></exception>
        private void ValidadeBigCastle()
        {
            try
            {
                ValidateLefttRookForBigCastle();
                ValidateBoardForBigCastle();
            }
            catch (Exception e)
            {
                throw new CastleNotAllowedException(e.Message);
            }
        }

        /// <summary>
        /// [EN] Validate if the left rook meets the requirements for big castle movement.
        /// [PT] Verifica se a torre da esquerda cumpre os requisitos para o roque grande.
        /// </summary>
        /// <exception cref="GameException"></exception>
        private void ValidateLefttRookForBigCastle()
        {
            try
            {
                Piece leftTower = Board.GetPiece(new Position(Position.Row, Convert.ToByte(Position.Column - 4)));
                ValidadeRookForCastle(leftTower);
            }
            catch (Exception e)
            {
                throw new GameException(e.Message);
            }
        }

        /// <summary>
        /// [EN] Checks if the board in the current position meets the requirements for big castle.
        /// [PT] Verifica se o tabuleiro na posição atual cumpre os requisitos para o roque grande. 
        /// </summary>
        /// <exception cref="CastleNotAllowedException"></exception>
        private void ValidateBoardForBigCastle()
        {
            try
            {
                Position positionOneSquareNextToKing = new(Position.Row, Convert.ToByte(Position.Column - 1));
                Position positionTwoSquaresNextToKing = new(Position.Row, Convert.ToByte(Position.Column - 2));
                Position positionThreeSquaresNextToKing = new(Position.Row, Convert.ToByte(Position.Column - 3));


                if (Board.ExistsPiece(positionOneSquareNextToKing) || Board.ExistsPiece(positionTwoSquaresNextToKing) || Board.ExistsPiece(positionThreeSquaresNextToKing))
                    throw new CastleNotAllowedException("It's not possible to big castle because the squares between the king and the left rook must be empty.");
            }
            catch (Exception e)
            {
                throw new CastleNotAllowedException(e.Message);
            }
        }

        public bool Moved()
        {
            return MovesPerformed > 0;
        }
        #endregion Methods
    }
}