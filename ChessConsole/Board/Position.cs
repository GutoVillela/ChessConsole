using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    /// <summary>
    /// [EN] Represents a piece position on the board using computer notation.
    /// [PT] Representa a posição de uma peça no tabuleiro usando a notação de computador.
    /// </summary>
    public class Position
    {
        #region Properties
        /// <summary>
        /// [EN] Row where the piece is on the board.
        /// [PT] Linha onde a peça está no tabuleiro.
        /// </summary>
        public byte Row { get; set; }

        /// <summary>
        /// [EN] Column where the piece is on the board.
        /// [PT] Coluna onde a peça está no tabuleiro.
        /// </summary>
        public byte Column { get; set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class Position.
        /// [PT] Cria uma nova instância da classe Position.
        /// </summary>
        /// <param name="row">[EN] Row where the piece is on the board. [PT] Linha onde a peça está no tabuleiro.</param>
        /// <param name="column">[EN] Column where the piece is on the board. [PT] Coluna onde a peça está no tabuleiro.</param>
        public Position(byte row, byte column)
        {
            Row = row;
            Column = column;
        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
        #endregion Methods

    }
}
