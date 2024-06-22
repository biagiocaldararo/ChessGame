using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int id, int set, Square square) : base(id, set, square) { }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var directions = new List<(int row, int col)> { (1, 1), (1, -1), (-1, 1), (-1, -1) };

            foreach (var (row, col) in directions)
            {
                bool stop = false;

                for (int r = Square.Row, c = Square.Column; !stop; r += row, c += col)
                { 
                    var square = board.GetSquare(r + row, c + col);

                    if (square != null && (square.Piece == null || square.Piece.Set != Set))
                    {
                        legalSquare.Add(square);
                        stop = square.Piece != null && square.Piece.Set != Set;
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }

            return legalSquare;
        }
    }
}
