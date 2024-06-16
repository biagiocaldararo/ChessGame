using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class King : Piece
    {
        public King(int id, int set, Square square) : base(id, set, square) { }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var directions = new List<(int Row, int Col)> { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) };

            foreach (var d in directions)
            {
                var square = board.GetSquare(Square.Row + d.Row, Square.Column + d.Col);

                if (square != null && (square.Piece == null || square.Piece.Set != Set))
                {
                    legalSquare.Add(square);
                }
            }

            return legalSquare;
        }
    }
}
