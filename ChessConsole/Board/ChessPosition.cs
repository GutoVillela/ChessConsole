﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Board
{
    /// <summary>
    /// [EN] Represents a piece position on the board using chess notation.
    /// [PT] Representa a posição de uma peça no tabuleiro usando a notação de xadrez.
    /// </summary>
    internal class ChessPosition
    {
        #region Properties
        /// <summary>
        /// [EN] Column where the piece is on the board.
        /// [PT] Coluna onde a peça está no tabuleiro.
        /// </summary>
        public char Column { get; set; }

        /// <summary>
        /// [EN] Row where the piece is on the board.
        /// [PT] Linha onde a peça está no tabuleiro.
        /// </summary>
        public int Row { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// [EN] Creates a new instance of the class ChessPosition.
        /// [PT] Cria uma nova instância da classe ChessPosition.
        /// </summary>
        /// <param name="row">[EN] Row where the piece is on the board. [PT] Linha onde a peça está no tabuleiro.</param>
        /// <param name="column">[EN] Column where the piece is on the board. [PT] Coluna onde a peça está no tabuleiro.</param>
        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }
        #endregion Constructor

        #region Methods
        public override string ToString()
        {
            return String.Concat(Column, Row);
        }

        /// <summary>
        /// [EN] Converts the ChessPosition a computer notation Position object.
        /// [PT] Converte a classe ChessPosition para um objeto Position em notação computacional.
        /// </summary>
        /// <param name="row">[EN] Size of the board row. [PT] Tamanho da linha do tabuleiro.</param>
        /// <returns></returns>
        public Position ToPosition(int boardRowSize)
        {
            return new Position(row: boardRowSize - Row, column: Column - 'A');
        }
        #endregion Methods
    }
}
