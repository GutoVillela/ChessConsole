﻿using ChessConsole.Board;
using ChessConsole.Board.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents a Queen piece.
    /// [PT] Representa uma peça de Dama.
    /// </summary>
    public class Queen : Piece
    {
        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Queen.
        /// [PT] Cria uma nova instância da classe Queen.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <param name="board">[EN] Board associated to the piece. [PT] Tabuleiro associado à peça.</param>
        public Queen(Color color, ChessBoard board) : base(color, board)
        {

        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return "D";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[ChessBoard.ROWS, ChessBoard.COLUMNS];
            Position position;

            #region Rook moves
            // [EN] Check positions above. [PT] Checar posições acima.
            if (Position.Row > 0)
            {
                position = new Position(Convert.ToByte(Position.Row - 1), Position.Column);
                while (Board.CheckPosition(position) && IsMoveAllowed(position))
                {
                    possibleMoves[position.Row, position.Column] = true;

                    // [EN] Finish while when we find the first adversary piece on the allowed position
                    // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                    if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                        break;

                    position.Row--;
                }
            }

            // [EN] Check positions below. [PT] Checar posições abaixo
            position = new Position(Convert.ToByte(Position.Row + 1), Position.Column);
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
            position = new Position(Position.Row, Convert.ToByte(Position.Column + 1));
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
            if (Position.Column > 0)
            {
                position = new Position(Position.Row, Convert.ToByte(Position.Column - 1));
                while (Board.CheckPosition(position) && IsMoveAllowed(position))
                {
                    possibleMoves[position.Row, position.Column] = true;

                    // [EN] Finish while when we find the first adversary piece on the allowed position
                    // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                    if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                        break;

                    position.Column--;
                }
            }
            #endregion Rook moves

            #region Bishop moves
            // [EN] Check positions in NO. [PT] Checar posições à Noroeste.
            if (Position.Row > 0 && Position.Column > 0)
            {
                position = new Position(Convert.ToByte(Position.Row - 1), Convert.ToByte(Position.Column - 1));
                while (Board.CheckPosition(position) && IsMoveAllowed(position))
                {
                    possibleMoves[position.Row, position.Column] = true;

                    // [EN] Finish while when we find the first adversary piece on the allowed position
                    // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                    if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                        break;

                    position.Row--;
                    position.Column--;
                }
            }

            // [EN] Check positions in NE. [PT] Checar posições à nordeste.
            if (Position.Row > 0)
            {
                position = new Position(Convert.ToByte(Position.Row - 1), Convert.ToByte(Position.Column + 1));
                while (Board.CheckPosition(position) && IsMoveAllowed(position))
                {
                    possibleMoves[position.Row, position.Column] = true;

                    // [EN] Finish while when we find the first adversary piece on the allowed position
                    // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                    if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                        break;

                    position.Row--;
                    position.Column++;
                }
            }

            // [EN] Check positions in SE. [PT] Checar posições à sudeste.
            position = new Position(Convert.ToByte(Position.Row + 1), Convert.ToByte(Position.Column + 1));
            while (Board.CheckPosition(position) && IsMoveAllowed(position))
            {
                possibleMoves[position.Row, position.Column] = true;

                // [EN] Finish while when we find the first adversary piece on the allowed position
                // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                    break;

                position.Row++;
                position.Column++;
            }

            // [EN] Check positions in SO. [PT] Checar posições à sudoeste.
            if (Position.Column > 0)
            {
                position = new Position(Convert.ToByte(Position.Row + 1), Convert.ToByte(Position.Column - 1));
                while (Board.CheckPosition(position) && IsMoveAllowed(position))
                {
                    possibleMoves[position.Row, position.Column] = true;

                    // [EN] Finish while when we find the first adversary piece on the allowed position
                    // [PT] Terinar while quando encontrarmos a primeira peça adversária em uma posição permitida
                    if (Board.ExistsPiece(position) && Board.GetPiece(position).Color != Color)
                        break;

                    position.Row++;
                    position.Column--;
                }
            }
            #endregion Bishop moves

            return possibleMoves;
        }
        #endregion Methods
    }
}
