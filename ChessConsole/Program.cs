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
                Match match = new();
                match.Board.PlacePiece(new Rook(Board.Enums.PieceColor.White, match.Board), new ChessPosition('A', 3).ToPosition(ChessBoard.ROWS));

                do
                {
                    Console.Clear();
                    Print.PrintBoard(match.Board);

                    Console.WriteLine();

                    Console.WriteLine($"Turn {match.Turn}.");
                    Console.WriteLine($"Player {match.CurrentPlayer}.");

                    Console.Write("Choose a piece position: ");
                    Position fromPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                    if (!match.Board.ExistsPiece(fromPosition))
                        continue;

                    Console.Clear();
                    bool [,] possibleMoves = match.Board.GetPiece(fromPosition).PossibleMoves();

                    Print.PrintBoard(match.Board, possibleMoves);

                    Console.Write("Enter a new position: ");
                    Position toPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                    match.PerformMovement(match.Board.GetPiece(fromPosition), toPosition);

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
