using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Rook piece.
    /// [PT] Representa uma peça de Torre.
    /// </summary>
    public class Rook : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Rook.
        /// [PT] Cria uma nova instância da classe Rook.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] Tabuleiro associado à peça.</param>
        public Rook(PieceColor color, ChessBoard board) : base(color, board)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "T";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[ChessBoard.ROWS, ChessBoard.COLUMNS];
            
            Position position;

            // [EN] Check positions above. [PT] Checar posições acima.
            position = new Position(Position.Row - 1, Position.Column);
            while(Board.CheckPosition(position) && IsMoveAllowed(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                // [EN] Finish while when we find the first adversary piece on the allowed position
                // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                    break;

                position.Row--;
            }

            // [EN] Check positions below. [PT] Checar posições abaixo
            position = new Position(Position.Row + 1, Position.Column);
            while (Board.CheckPosition(position) && IsMoveAllowed(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                // [EN] Finish while when we find the first adversary piece on the allowed position
                // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                    break;

                position.Row++;
            }

            // [EN] Check right positions. [PT] Checar posições à direita
            position = new Position(Position.Row, Position.Column + 1);
            while (Board.CheckPosition(position) && IsMoveAllowed(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                // [EN] Finish while when we find the first adversary piece on the allowed position
                // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                    break;

                position.Column++;
            }

            // [EN] Check left positions. [PT] Checar posições à esquerda
            position = new Position(Position.Row, Position.Column + 1);
            while (Board.CheckPosition(position) && IsMoveAllowed(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                // [EN] Finish while when we find the first adversary piece on the allowed position
                // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                    break;

                position.Column++;
            }


            return possibleMoves;
        }
        #endregion Methods
    }
}
