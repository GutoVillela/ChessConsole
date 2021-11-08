using System;
using ChessConsole.Board;

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
        public const char PIECE_PLACEHOLDER = '-';
        #endregion Constants

        #region Methods
        /// <summary>
        /// [EN] Prints the board to the console.
        /// [PT] Imprime o tabuleiro no console.
        /// </summary>
        /// <param name="board"></param>
        public static void PrintBoard(ChessBoard board)
        {
            if (board is null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            for (int i = 0; i < board.Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < board.Pieces.GetLength(1); j++)
                {
                    if (board.Pieces[i, j] is null)
                        Console.Write(PIECE_PLACEHOLDER + " ");
                    else
                        Console.Write(board.Pieces[i, j] + " ");
                }

                // [EN] Print a new line on each line of the board
                // [PT] Imprimir uma linha em branco em cada linha do tabuleiro
                Console.WriteLine();
            }
        }
        #endregion Methods
    }
}
