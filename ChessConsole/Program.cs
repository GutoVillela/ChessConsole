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
                match.Board.PlacePiece(new Rook(Board.Enums.PieceColor.White), new ChessPosition('A', 3).ToPosition(ChessBoard.ROWS));

                do
                {
                    Console.Clear();
                    Print.PrintBoard(match.Board);

                    Console.WriteLine();

                    Console.Write("Choose a piece position: ");
                    Position fromPosition = Print.ReadChessPosition().ToPosition(ChessBoard.ROWS);

                    if (!match.Board.ExistsPiece(fromPosition))
                        continue;

                    Console.Clear();
                    bool [,] possibleMoves = match.Board.GetPiece(fromPosition).PossibleMoves(match.Board);

                    Print.PrintBoard(match.Board, possibleMoves);

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
