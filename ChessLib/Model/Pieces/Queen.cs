using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Queen : Piece
    {
        public Queen(bool white, Square square) : base(white, square) { }

        public override List<Square> GetLegalSquares()
        {
            throw new NotImplementedException();
        }
    }
}
