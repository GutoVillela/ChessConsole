using ChessConsole.Board;
using ChessConsole.Game;
using ChessConsole.UI;
using System;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();

            board.PlacePiece(new King(Board.Enums.PieceColor.White), new Position(0, 0));
            board.PlacePiece(new Queen(Board.Enums.PieceColor.Black), new Position(0, 1));
            board.PlacePiece(new Rook(Board.Enums.PieceColor.White), new Position(0, 2));
            board.PlacePiece(new Bishop(Board.Enums.PieceColor.Black), new Position(0, 3));
            board.PlacePiece(new Knight(Board.Enums.PieceColor.White), new Position(0, 4));
            board.PlacePiece(new Pawn(Board.Enums.PieceColor.Black), new Position(0, 5));

            Print.PrintBoard(board);
            
        }
    }
}
