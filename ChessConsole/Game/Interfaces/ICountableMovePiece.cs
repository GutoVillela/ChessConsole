using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole.Game.Interfaces
{
    internal interface ICountableMovePiece
    {
        /// <summary>
        /// Number of movements performed from this piece.
        /// </summary>
        public ushort MovesPerformed { get; set; }
    }
}
