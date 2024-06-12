using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Pawn : Piece
    {
        public bool Promoted { get; set; }

        public Pawn(int set, Square square) : base(set, square)
        {
            Promoted = false;
        }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            if (!Promoted)
            {
                if ((Set == Board.WHITE && Square.Row < Board.DIM - 1) || (Set == Board.BLACK && Square.Row > 0))
                {
                    legalSquare.Add(board.Squares[Square.Row + (Set * 1), Square.Column]);
                }

                if (!Moved)
                {
                    legalSquare.Add(board.Squares[Square.Row + (Set * 2), Square.Column]);
                }
            }

            return legalSquare;
        }
    }
}
