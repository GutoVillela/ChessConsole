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
        /// [EN] Match pieces in game.
        /// [PT] Peças da partida em jogo.
        /// </summary>
        private HashSet<Piece> Pieces { get; set; }

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
        public void MovePiece(Piece piece, Position to)
        {
            // TODO Verify if the piece is a tower to increment a move
            Board.RemovePiece(piece.Position);
            Piece capturedPiece = Board.RemovePiece(to);
            Board.PlacePiece(piece, to);

            if(capturedPiece != null)
                CapturedPieces.Add(capturedPiece);
        }

        /// <summary>
        /// [EN] Performs a players movement.
        /// [PT] Realiza o movimento de um jogador.
        /// </summary>
        /// <param name="piece">[EN] Piece to move. [PT] Peça a ser movida.</param>
        /// <param name="to">[EN] Piece's new position. [PT] Nova posição da peça.</param>
        public void PerformMovement(Piece piece, Position to)
        {
            MovePiece(piece, to);
            Turn++;
            ChangePlayer();
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
        #endregion Methods
    }
}