using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a King piece.
    /// [PT] Representa uma peça de Rei.
    /// </summary>
    public class King : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class King.
        /// [PT] Cria uma nova instância da classe King.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] Tabuleiro associado à peça.</param>
        public King(PieceColor color, ChessBoard board) : base(color, board)
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
            position = new Position(Position.Row - 1, Position.Column);
            if(Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            position = new Position(Position.Row - 1, Position.Column + 1);
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;
            
            position = new Position(Position.Row, Position.Column + 1);
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            position = new Position(Position.Row + 1, Position.Column + 1);
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            position = new Position(Position.Row + 1, Position.Column - 1);
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            position = new Position(Position.Row, Position.Column - 1);
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            position = new Position(Position.Row - 1, Position.Column - 1);
            if (Board.CheckPosition(position) && IsMoveAllowed(position))
                possibleMoves[position.Row, position.Column] = true;

            return possibleMoves;
        }
        
        #endregion Methods
    }
}