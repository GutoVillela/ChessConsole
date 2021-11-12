﻿using ChessConsole.Board;
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
                match.Board.PlacePiece(new Rook(Board.Enums.Color.White, match.Board), new ChessPosition('A', 3).ToPosition(ChessBoard.ROWS));

                do
                {
                    try
                    {
                        Console.Clear();
                        Print.PrintBoard(match.Board);

                        Console.WriteLine();

                        Console.WriteLine($"Turn {match.Turn}.");
                        Console.WriteLine($"Player {match.CurrentPlayer}.");

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

                        match.PerformMovement(match.Board.GetPiece(fromPosition), toPosition);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

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
