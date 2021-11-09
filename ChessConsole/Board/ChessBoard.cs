using ChessConsole.Board.Exceptions;

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
        public static readonly int ROWS = 8;

        /// <summary>
        /// [EN] Number of columns on the board.
        /// [PT] Número de colunas do tabuleiro.
        /// </summary>
        public static readonly int COLUMNS = 8;
        #endregion Constants

        #region Properties
        /// <summary>
        /// [EN] Pieces positioned on the board.
        /// [PT] Peças posicionadas no tabuleiro.
        /// </summary>
        public Piece[,] Pieces { get; private set; } = new Piece[ROWS, COLUMNS];

        #endregion Properties

        #region Methods
        /// <summary>
        /// [EN] Places a piece on the board at the given position.
        /// [PT] Posiciona uma peça no tabuleiro na posição indicada.
        /// </summary>
        /// <param name="piece">[EN] Piece to be placed. [PT] Peça a ser posicionada.</param>
        /// <param name="piece">[EN] Position to place the piece. [PT] Posição a se colocar a peça.</param>
        public void PlacePiece(Piece piece, Position position)
        {
            ValidatePosition(position);

            if (ExistsPiece(position))
                throw new BoardException($"There's already a piece placed on the position [{position.Row}, {position.Column}].");

            piece.Position = position;
            Pieces[position.Row, position.Column] = piece;
        }

        /// <summary>
        /// [EN] Validates if the given position is inside the board range and throw an exception if it is not.
        /// [PT] Valida se a posição fornecida está dentro do intervalo do tabuleiro e lança uma exceção caso não esteja.
        /// </summary>
        /// <param name="position">[EN] Position to be validated. [PT] Posição a ser validade.</param>
        private void ValidatePosition(Position position)
        {
            if (position.Row >= Pieces.GetLength(0) || position.Column >= Pieces.GetLength(1) || position.Column < 0 || position.Row < 0)
                throw new BoardException($"The given position is out of the board range. Please provide a position between row {Pieces.GetLength(0) - 1} and column {Pieces.GetLength(1) - 1}.");
        }

        /// <summary>
        /// [EN] Checks if there's already a piece placed on the given position.
        /// [PT] Verifica se já existe uma peça colocada na posição fornecida.
        /// </summary>
        /// <param name="position">[EN] Position to check. [PT] Posição para verificar.</param>
        /// <returns>[EN] True if there's a piece or false if there's not. [PT] Verdadeiro se houver uma peça ou falso se não houver.</returns>
        private bool ExistsPiece(Position position)
        {
            ValidatePosition(position);
            return Pieces[position.Row, position.Column] != null;
        }
        #endregion Methods
    }
}