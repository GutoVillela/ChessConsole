using ChessConsole.Board;
using ChessConsole.Board.Exceptions;
using ChessConsole.Game;
using ChessConsole.UI;
using System;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Match match = new Match();

                do
                {
                    Console.Clear();
                    Print.PrintBoard(match.Board);

                    Console.WriteLine();

                    Console.Write("Choose a piece position: ");
                    Position fromPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                    if (!match.Board.ExistsPiece(fromPosition))
                        continue;

                    Console.Write("Enter a new position: ");
                    Position toPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                    match.MovePiece(match.Board.GetPiece(fromPosition), toPosition);

                }
                while (!match.IsFinished);

            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
