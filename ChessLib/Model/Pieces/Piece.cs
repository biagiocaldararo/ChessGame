using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public abstract class Piece
    {
        public bool White { get; set; }

        public Square Square { get; set; }

        public bool Moved { get; set; }

        public bool Captured { get; set; }

        public Piece(bool white, Square square)
        {
            White = white;
            Square = square;
            Moved = false;
            Captured = false;
        }

        public abstract List<Square> GetLegalSquares();

        public void SetSquare(Square square)
        {
            Square = square;
            Moved = true;
        }
    }
}
