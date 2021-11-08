using ChessConsole.Board;
using ChessConsole.UI;
using System;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            Print.PrintBoard(board);
        }
    }
}
