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
            var legalSquare = new List<Square>();

            var combinations = new List<(int Row, int Col)> { (1, 2), (1, -2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1), (-2, -1) };

            foreach (var c in combinations)
            {
                var square = board.GetSquare(Square.Row + c.Row, Square.Column + c.Col);

                if (square != null && (square.Piece == null || square.Piece.Set != Set))
                {
                    legalSquare.Add(square);
                }
            }

            return legalSquare;
        }
    }
}
