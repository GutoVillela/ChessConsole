using ChessConsole.Board.Exceptions;
using ChessConsole.Game;

namespace ChessConsole.Board
{
    /// <summary>
    /// [EN] Represents the chess board.
    /// [PT] Representa o tabuleiro de xadrez.
    /// </summary>
    public class ChessBoard
    {
        #region Constants
        /// <summary>
        /// [EN] Number of lines on the board.
        /// [PT] Número de linhas do tabuleiro.
        /// </summary>
        public static readonly byte ROWS = 8;

        /// <summary>
        /// [EN] Number of columns on the board.
        /// [PT] Número de colunas do tabuleiro.
        /// </summary>
        public static readonly byte COLUMNS = 8;
        #endregion Constants

        #region Properties
        /// <summary>
        /// [EN] Pieces positioned on the board.
        /// [PT] Peças posicionadas no tabuleiro.
        /// </summary>
        private Piece[,] Pieces { get; set; } = new Piece[ROWS, COLUMNS];

        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class ChessBoard.
        /// [PT] Cria uma nova instância da classe ChessBoard.
        /// </summary>
        public ChessBoard()
        {
            ResetPieces();
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// [EN] Gets the piece in the given position.
        /// [PT] Obtém a peça na posição indicada.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Piece GetPiece(Position position)
        {
            if (!ExistsPiece(position))
                throw new BoardException($"There's no piece in the position {position}.");

            return Pieces[position.Row, position.Column]; 
        }

        /// <summary>
        /// [EN] Places a piece on the board at the given position.
        /// [PT] Posiciona uma peça no tabuleiro na posição indicada.
        /// </summary>
        /// <param name="piece">[EN] Piece to be placed. [PT] Peça a ser posicionada.</param>
        /// <param name="position">[EN] Position to place the piece. [PT] Posição a se colocar a peça.</param>
        public void PlacePiece(Piece piece, Position position)
        {
            ValidatePosition(position);

            if (ExistsPiece(position))
                throw new BoardException($"There's already a piece placed on the position [{position.Row}, {position.Column}].");

            piece.Position = position;
            Pieces[position.Row, position.Column] = piece;
        }

        /// <summary>
        /// [EN] Removes a piece on the board at the given position.
        /// [PT] Remove uma peça no tabuleiro na posição indicada.
        /// </summary>
        /// <param name="position">[EN] Piece's position. [PT] Posição atual da peça.</param>
        /// <returns>[EN] Returns the removed piece or null if there was no piece. [PT] Retorna a peça removida ou null caso não exista peça.</returns>
        public Piece RemovePiece(Position position)
        {
            if(!ExistsPiece(position))
                return null;

            Piece piece = Pieces[position.Row,position.Column];
            piece.Position = null;
            Pieces[position.Row, position.Column] = null;
            return piece;
        }

        /// <summary>
        /// [EN] Clear and resets all the pieces' position. [PT] Limpa e reseta a posição de todas as peças.
        /// </summary>
        public void ResetPieces()
        {
            Pieces = new Piece[ROWS, COLUMNS];

            // [EN] Place white pieces. [PT] Posicionar peças brancas
            PlacePiece(new Rook(Enums.Color.White, this), new ChessPosition('A', 1).ToPosition(ROWS));
            PlacePiece(new Knight(Enums.Color.White, this), new ChessPosition('B', 1).ToPosition(ROWS));
            PlacePiece(new Bishop(Enums.Color.White, this), new ChessPosition('C', 1).ToPosition(ROWS));
            PlacePiece(new Queen(Enums.Color.White, this), new ChessPosition('D', 1).ToPosition(ROWS));
            PlacePiece(new King(Enums.Color.White, this), new ChessPosition('E', 1).ToPosition(ROWS));
            PlacePiece(new Bishop(Enums.Color.White, this), new ChessPosition('F', 1).ToPosition(ROWS));
            PlacePiece(new Knight(Enums.Color.White, this), new ChessPosition('G', 1).ToPosition(ROWS));
            PlacePiece(new Rook(Enums.Color.White, this), new ChessPosition('H', 1).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('A', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('B', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('C', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('D', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('E', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('F', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('G', 2).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.White, this), new ChessPosition('H', 2).ToPosition(ROWS));

            // [EN] Place black pieces. [PT] Posicionar peças pretas.
            PlacePiece(new Rook(Enums.Color.Black, this), new ChessPosition('A', 8).ToPosition(ROWS));
            PlacePiece(new Knight(Enums.Color.Black, this), new ChessPosition('B', 8).ToPosition(ROWS));
            PlacePiece(new Bishop(Enums.Color.Black, this), new ChessPosition('C', 8).ToPosition(ROWS));
            PlacePiece(new Queen(Enums.Color.Black, this), new ChessPosition('D', 8).ToPosition(ROWS));
            PlacePiece(new King(Enums.Color.Black, this), new ChessPosition('E', 8).ToPosition(ROWS));
            PlacePiece(new Bishop(Enums.Color.Black, this), new ChessPosition('F', 8).ToPosition(ROWS));
            PlacePiece(new Knight(Enums.Color.Black, this), new ChessPosition('G', 8).ToPosition(ROWS));
            PlacePiece(new Rook(Enums.Color.Black, this), new ChessPosition('H', 8).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('A', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('B', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('C', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('D', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('E', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('F', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('G', 7).ToPosition(ROWS));
            PlacePiece(new Pawn(Enums.Color.Black, this), new ChessPosition('H', 7).ToPosition(ROWS));
        }

        /// <summary>
        /// [EN] Checks if there's already a piece placed on the given position.
        /// [PT] Verifica se já existe uma peça colocada na posição fornecida.
        /// </summary>
        /// <param name="position">[EN] Position to check. [PT] Posição para verificar.</param>
        /// <returns>[EN] True if there's a piece or false if there's not. [PT] Verdadeiro se houver uma peça ou falso se não houver.</returns>
        public bool ExistsPiece(Position position)
        {
            ValidatePosition(position);
            return Pieces[position.Row, position.Column] != null;
        }

        /// <summary>
        /// [EN] Checks if the given position exists on the board.
        /// [PT] Verifica a posição fornecida existe no tabuleiro.
        /// </summary>
        /// <param name="position">[EN] Position to check. [PT] Posição para verificar.</param>
        /// <returns>[EN] True if the position exists and false if the position doesn't exist. [PT] Verdadeiro se posição existir e false se não existir.</returns>
        public bool CheckPosition(Position position)
        {
            return !(position.Row >= Pieces.GetLength(0) || position.Column >= Pieces.GetLength(1) || position.Column < 0 || position.Row < 0);
        }

        /// <summary>
        /// [EN] Validates if the given position is inside the board range and throw an exception if it is not.
        /// [PT] Valida se a posição fornecida está dentro do intervalo do tabuleiro e lança uma exceção caso não esteja.
        /// </summary>
        /// <param name="position">[EN] Position to be validated. [PT] Posição a ser validade.</param>
        private void ValidatePosition(Position position)
        {
            if (!CheckPosition(position))
                throw new BoardException($"The given position is out of the board range. Please provide a position between row {Pieces.GetLength(0) - 1} and column {Pieces.GetLength(1) - 1}.");
        }

        
        #endregion Methods
    }
}