using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Game.Interfaces
{
    internal interface ICountableMovePiece
    {
        #region Properties
        /// <summary>
        /// [EN] Number of movements performed from this piece.
        /// [PT] Número de movimentos realizados pela peça.
        /// </summary>
        public ushort MovesPerformed { get; set; }
        #endregion Properties

        #region Methods
        /// <summary>
        /// [EN] Checks if the piece has already made a move. [PT] Verifica se a peça já fez algum movimento.
        /// </summary>
        /// <returns>[EN] True if the piece has already moved and false otherwise. [PT] True se a peça já se moveu e falso caso contrário.</returns>
        public bool Moved();
        #endregion Methods
    }
}
