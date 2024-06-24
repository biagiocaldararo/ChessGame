using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Knight : Piece
    {
        public Knight(int id, int set, Square square) : base(id, set, square) { }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var combinations = new List<(int row, int col)> { (1, 2), (1, -2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1), (-2, -1) };

            foreach (var (row, col) in combinations)
            {
                var square = board.GetSquare(Square.Row + row, Square.Column + col);

                if (square != null && (square.Piece == null || square.Piece.Set != Set))
                {
                    legalSquare.Add(square);
                }
            }

            return legalSquare;
        }
    }
}
