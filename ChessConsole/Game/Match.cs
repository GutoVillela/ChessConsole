using ChessConsole.Board;
using ChessConsole.Game.Enums;
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
    internal class Match
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
        public int Turn { get; set; }

        /// <summary>
        /// [EN] Current turn player.
        /// [PT] Jogador do turno atual.
        /// </summary>
        public PlayerColor CurrentPlayer { get; set; }

        /// <summary>
        /// [EN] Defines if the match is finished.
        /// [PT] Define se a partida está terminada.
        /// </summary>
        public bool IsFinished { get; private set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Match.
        /// [PT] Cria uma nova instância da classe Match.
        /// </summary>
        public Match()
        {
            Board = new ChessBoard();
            Turn = 1;
            CurrentPlayer = PlayerColor.White;
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
        }
        #endregion Methods
    }
}