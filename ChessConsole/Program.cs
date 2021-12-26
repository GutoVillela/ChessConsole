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
                match.Board.PlacePiece(new Rook(Board.Enums.Color.White, match.Board), new ChessPosition('G', 1).ToPosition(ChessBoard.ROWS));
                match.Board.PlacePiece(new King(Board.Enums.Color.Black, match.Board), new ChessPosition('A', 8).ToPosition(ChessBoard.ROWS));
                match.Board.PlacePiece(new King(Board.Enums.Color.White, match.Board), new ChessPosition('C', 7).ToPosition(ChessBoard.ROWS));

                do
                {
                    try
                    {
                        Console.Clear();
                        Print.PrintMatch(match);

                        Console.Write("Choose a piece position: ");
                        Position fromPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                        match.ValidateFromPosition(fromPosition);

                        if (!match.Board.ExistsPiece(fromPosition))
                            continue;

                        Console.Clear();
                        bool [,] possibleMoves = match.Board.GetPiece(fromPosition).PossibleMoves();

                        Print.PrintBoard(match.Board, possibleMoves);

                        Console.Write("Enter a new position: ");
                        Position toPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                        match.ValidateToPosition(match.Board.GetPiece(fromPosition), toPosition);

                        match.PerformMovement(fromPosition, toPosition);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                while (!match.IsFinished);

                Console.Clear();
                Print.PrintMatch(match);
                Console.WriteLine($"Game's over! Winner: {match.CurrentPlayer}");

            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
