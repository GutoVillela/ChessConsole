﻿using System;
using ChessConsole.Board;
using ChessConsole.Board.Enums;

namespace ChessConsole.UI
{
    /// <summary>
    /// [EN] Class responsible to print the user interface to the console.
    /// [PT] Classe responsável por imprimir a interface de usuário no console.
    /// </summary>
    public static class Print
    {
        #region Constants
        /// <summary>
        /// [EN] Piece's placeholder.
        /// [PT] Placeholder da peça (caractere a ser impresso nas casas do tabuleiro sem peças)
        /// </summary>
        private const char PIECE_PLACEHOLDER = '-';
        #endregion Constants

        #region Methods
        /// <summary>
        /// [EN] Prints the board to the console.
        /// [PT] Imprime o tabuleiro no console.
        /// </summary>
        /// <param name="board">[EN] Board to be printed. [PT] Tabuleiro a ser impresso.</param>
        public static void PrintBoard(ChessBoard board)
        {
            if (board is null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            for (int i = 0; i < ChessBoard.ROWS; i++)
            {
                Console.Write(ChessBoard.ROWS - i + " ");

                for (int j = 0; j < ChessBoard.COLUMNS; j++)
                {
                    Position position = new(i, j);

                    if (!board.ExistsPiece(position))
                        Console.Write(PIECE_PLACEHOLDER + " ");
                    else
                    {
                        PrintPiece(board.GetPiece(position));
                        
                    }
                }

                // [EN] Print a new line on each line of the board
                // [PT] Imprimir uma linha em branco em cada linha do tabuleiro
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("  ");

            for (int i = 0; i < ChessBoard.COLUMNS; i++)
            {
                char column = (char)('A' + i);
                Console.Write(column + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// [EN] Prints the board to the console and highlight the indicated positions.
        /// [PT] Imprime o tabuleiro no console e destava as posições marcadas.
        /// </summary>
        /// <param name="board">[EN] Board to be printed. [PT] Tabuleiro a ser impresso.</param>
        /// <param name="highlightPositions">[EN] Board positions to be highlighted. [PT] Posições do tabuleiro a serem destacadas.</param>
        public static void PrintBoard(ChessBoard board, bool[,] highlightPositions)
        {
            if (board is null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if(highlightPositions is null)
            {
                throw new ArgumentNullException(nameof(highlightPositions));
            }

            if(ChessBoard.ROWS != highlightPositions.GetLength(0) || ChessBoard.COLUMNS != highlightPositions.GetLength(1))
            {
                throw new ArgumentException("The given matrix must have the same size as the ChessBoard.");
            }

            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor highlightColor = ConsoleColor.DarkGray;

            for (int i = 0; i < ChessBoard.ROWS; i++)
            {
                Console.Write(ChessBoard.ROWS - i + " ");

                for (int j = 0; j < ChessBoard.COLUMNS; j++)
                {
                    Console.BackgroundColor = highlightPositions[i, j] ? highlightColor : originalColor;

                    Position position = new(i, j);

                    if (!board.ExistsPiece(position))
                        Console.Write(PIECE_PLACEHOLDER + " ");
                    else
                    {
                        PrintPiece(board.GetPiece(position));
                    }

                    Console.BackgroundColor = originalColor;
                }

                // [EN] Print a new line on each line of the board
                // [PT] Imprimir uma linha em branco em cada linha do tabuleiro
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("  ");

            for (int i = 0; i < ChessBoard.COLUMNS; i++)
            {
                char column = (char)('A' + i);
                Console.Write(column + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// [EN] Reads a new chess position from user input.
        /// [PT] Lê uma posição de xadrez via input do usuário.
        /// </summary>
        /// <returns>[EN] ChessPosition entered by user. [PT] Posição de xadrez inserida pelo usuário.</returns>
        public static ChessPosition ReadChessPosition()
        {
            string input = Console.ReadLine();
            char column = input[0];
            int row = Convert.ToInt32(input[1].ToString());
            return new ChessPosition(column, row);
        }

        /// <summary>
        /// [EN] Prints the piece to the console.
        /// [PT] Imprime a peça no console.
        /// </summary>
        /// <param name="piece">[EN] Piece to print. [PT] Peça a imprimir.</param>
        private static void PrintPiece(Piece piece)
        {
            if (piece is null)
            {
                Console.Write(PIECE_PLACEHOLDER + " ");
            }
            else
            {
                if (piece.Color == PieceColor.White)
                    Console.Write(piece + " ");
                else
                {
                    // [EN] Print black pieces in yellow
                    // [PT] Imprimir peças pretas em amarelo
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                    Console.Write(" ");
                }
            }
        }

        #endregion Methods
    }
}
