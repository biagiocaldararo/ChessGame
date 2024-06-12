using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Knight : Piece
    {
        public Knight(int set, Square square) : base(set, square) { }

        public override List<Square> GetLegalSquares(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
