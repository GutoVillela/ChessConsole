using ChessConsole.Board;
using ChessConsole.Board.Enums;
using ChessConsole.Board.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Game
{
    /// <summary>
    /// [EN] Represents the chess match.
    /// [PT] Representa a partida de xadrez.
    /// </summary>
    public class Match
    {
        #region Properties
        /// <summary>
        /// [EN] Chess Board.
        /// [PT] Tabuleiro de xadrez.
        /// </summary>
        public ChessBoard Board { get; private set; }

        /// <summary>
        /// [EN] Game current turn.
        /// [PT] Turno atual do jogo.
        /// </summary>
        public int Turn { get; private set; }

        /// <summary>
        /// [EN] Current turn player.
        /// [PT] Jogador do turno atual.
        /// </summary>
        public Color CurrentPlayer { get; private set; }

        /// <summary>
        /// [EN] Defines if the match is finished.
        /// [PT] Define se a partida está terminada.
        /// </summary>
        public bool IsFinished { get; private set; }

        /// <summary>
        /// [EN] Match captured pieces.
        /// [PT] Peças capturadas da partida.
        /// </summary>
        private HashSet<Piece> CapturedPieces { get; set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Match.
        /// [PT] Cria uma nova instância da classe Match.
        /// </summary>
        public Match()
        {
            CapturedPieces = new HashSet<Piece>();
            Board = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// [EN] Moves a piece to the given position.
        /// [PT] Move a peça para a posição informada.
        /// </summary>
        /// <param name="piece">[EN] Piece to move. [PT] Peça a ser movida.</param>
        /// <param name="to">[EN] Piece's new position. [PT] Nova posição da peça.</param>
        /// <returns>[EN] Captured piece from the performed movemente or null if there was no piece captured. [PT] Peça capturada após movemente ou nulo caso não exista peça capturada.</returns>
        public Piece MovePiece(Piece piece, Position to)
        {
            Board.RemovePiece(piece.Position);
            Piece capturedPiece = Board.RemovePiece(to);
            Board.PlacePiece(piece, to);

            if(capturedPiece != null)
                CapturedPieces.Add(capturedPiece);

            // Verify if the piece is a tower to increment a move
            if (piece is Rook)
                (piece as Rook).MovesPerformed++;

            return capturedPiece;
        }

        /// <summary>
        /// [EN] Performs a players movement.
        /// [PT] Realiza o movimento de um jogador.
        /// </summary>
        /// <param name="from">[EN] Piece's current position. [PT] Posição atual da peça.</param>
        /// <param name="to">[EN] Piece's new position. [PT] Nova posição da peça.</param>
        public void PerformMovement(Position from, Position to)
        {
            Piece piece = Board.GetPiece(from);

            var capturedPiece = MovePiece(piece, to);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(from, to, capturedPiece);
                throw new BoardException("Invalid movement: you can't put yourself in check.");
            }

            // [EN] Indicates if the adversary king is in check after the performed movement.
            // [PT] Indica se o Rei adversário está em xeque depois do movimento realizado.
            King adversaryKing = GetKing(GetAdversasyColor(CurrentPlayer));
            adversaryKing.Check = IsInCheck(adversaryKing.Color);

            if (IsCheckMate(GetAdversasyColor(CurrentPlayer)))
            {
                IsFinished = true;
                return;
            }

            Turn++;
            ChangePlayer();
        }

        /// <summary>
        /// [EN] Undoes a performed movement.
        /// [PT] Desfaz o movimento realizado.
        /// </summary>
        /// <param name="piece">[EN] Moved piece's original position. [PT] Posição original da peça movida..</param>
        /// <param name="to">[EN] Piece's new position. [PT] Nova posição da peça.</param>
        /// <param name="capturedPiece">[EN] Captured piece after performed move. [PT] Peça capturada após movemento.</param>
        public void UndoMovement(Position from, Position to, Piece capturedPiece)
        {
            Piece pieceMoved = Board.RemovePiece(to);

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, to);
                CapturedPieces.Remove(capturedPiece);
            }

            // Verify if the piece is a tower to decrement a move
            if (pieceMoved is Rook)
                (pieceMoved as Rook).MovesPerformed++;

            Board.PlacePiece(pieceMoved, from);
        }

        /// <summary>
        /// [EN] Validates if player has choosen a valid from position. [PT] Valida se jogador selecionou uma posição de origem válida.
        /// </summary>
        /// <param name="position">[EN] Position to be validated. [PT] Posição para ser validada.</param>
        public void ValidateFromPosition(Position position)
        {
            if(position is null)
                throw new ArgumentNullException(nameof(position));

            if (!Board.CheckPosition(position))
                throw new BoardException("The chosen position doesn't exist on the board.");

            if(!Board.ExistsPiece(position))
                throw new BoardException("The chosen position doesn't have a piece on it.");

            if(Board.GetPiece(position).Color != CurrentPlayer)
                throw new BoardException("The chosen piece doens't belong to current player.");

            if(!Board.GetPiece(position).AnyPossibleMove())
                throw new BoardException("There is no possible move to the chosen piece. Please select another piece.");
        }

        /// <summary>
        /// [EN] Validates if player has choosen a valid to position. [PT] Valida se jogador selecionou uma posição de destino válida.
        /// </summary>
        /// <param name="piece">[EN] Position to be validated. [PT] Posição para ser validada.</param>
        /// <param name="position">[EN] Position to be validated. [PT] Posição para ser validada.</param>
        public void ValidateToPosition(Piece piece, Position position)
        {
            if (piece is null)
                throw new ArgumentNullException(nameof(piece));

            if (position is null)
                throw new ArgumentNullException(nameof(position));

            if (!piece.IsMovePossible(position))
                throw new BoardException("The chosen movement is not possible to this piece.");
        }

        /// <summary>
        /// [EN] Gets all captured pieces from the given color.
        /// [PT] Obtém todas as peças capturadas da cor fornecida.
        /// </summary>
        /// <param name="color">[EN] Piece color. [PT] Cor da peça.</param>
        /// <returns>[EN] All captured pieces from the given color. [PT] Todas as peças capturadas da cor fornecida.</returns>
        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            return CapturedPieces.Where(i => i.Color == color).ToHashSet();
        }

        /// <summary>
        /// [EN] Gets the pieces from the given color the are still in game.
        /// [PT] Obtém as peças da cor fornecida que ainda estão em jogo.
        /// </summary>
        /// <returns>[EN] Pieces the are still in game. [PT] Peças que ainda estão em jogo.</returns>
        public HashSet<Piece> GetPiecesInGame(Color color)
        {
            HashSet<Piece> piecesInGame = new();

            foreach (var item in Board.GetPiecesInGame())
            {
                if (item.Color == color)
                    piecesInGame.Add(item);
            }

            return piecesInGame;
        }

        /// <summary>
        /// [EN] Checks if the king from the given color is in check.
        /// [PT] Verifica se o rei da posição fornecida está em xeque.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool IsInCheck(Color color)
        {
            King king = GetKing(color);

            if (king is null)
                throw new BoardException("There is no king from the given color on the board.");

            foreach (Piece piece in GetPiecesInGame(GetAdversasyColor(color)))
            {
                bool[,] possibleMoves = piece.PossibleMoves();

                if (possibleMoves[king.Position.Row, king.Position.Column])
                    return true;
            }

            return false;
        }

        /// <summary>
        /// [EN] Checks if the king from the given color is in check mate.
        /// [PT] Verifica se o rei da posição fornecida está em xeque-mate.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool IsCheckMate(Color color)
        {
            if (!IsInCheck(color))
                return false;

            // Verify if any possible movement from the player's color could avoid check
            foreach(Piece piece in GetPiecesInGame(color))
            {
                bool[,] piecePossibleMoves = piece.PossibleMoves();
                for (byte i = 0; i < ChessBoard.ROWS; i++)
                {
                    for (byte j = 0; j < ChessBoard.COLUMNS; j++)
                    {
                        if(piecePossibleMoves[i, j])
                        {
                            Position pieceDestination = new Position(i, j);
                            Position pieceOriginalPosition = piece.Position;
                            Piece capturedPiece = MovePiece(piece, pieceDestination);
                            bool stillInCheckAfterPieceMovement = IsInCheck(color);
                            UndoMovement(pieceOriginalPosition, pieceDestination, capturedPiece);

                            if (!stillInCheckAfterPieceMovement)
                                return false; // There's a movement that avoids check mate.
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// [EN] Change current player.
        /// [PT] Muda jogador atual.
        /// </summary>
        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
                CurrentPlayer = Color.Black;
            else
                CurrentPlayer = Color.White;
        }

        /// <summary>
        /// [EN] Gets the adversary color to the given color.
        /// [PT] Obtém a cor adversáriA para a cor fornecida.
        /// </summary>
        /// <param name="color">[EN] Color. [PT] Cor.</param>
        /// <returns>[EN] Adversary color. [PT] Cor adversária.</returns>
        private Color GetAdversasyColor(Color color)
        {
            if(color == Color.White)
                return Color.Black;

            return Color.White;
        }

        /// <summary>
        /// [EN] Gets the King Piece from the given color.
        /// [PT] Obtém a peça Rei da cor fornecida.
        /// </summary>
        /// <param name="color">[EN] Color. [PT] Cor.</param>
        /// <returns>[EN] King from the given color. [PT] Rei da cor fornecida.</returns>
        private King GetKing(Color color)
        {
            foreach (Piece piece in Board.GetPiecesInGame())
            {
                if (piece is King && piece.Color == color)
                    return piece as King;
            }

            return null;
        }
        #endregion Methods
    }
}