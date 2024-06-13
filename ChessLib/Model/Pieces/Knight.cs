using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Knight : Piece
    {
        private static readonly List<(int Row, int Col)> Combinations = [(1, 2), (1, -2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1), (-2, -1)];

        public Knight(int set, Square square) : base(set, square) { }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            foreach (var c in Combinations)
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
