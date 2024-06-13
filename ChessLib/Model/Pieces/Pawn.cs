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
                //Muovi in avanti di 1
                var square = board.GetSquare(Square.Row + (Set * 1), Square.Column);

                if (square != null && square.Piece == null)
                {
                    legalSquare.Add(square);
                }

                //Muovi in avanti di 2 se mai mosso
                if (!Moved)
                {
                    square = board.GetSquare(Square.Row + (Set * 2), Square.Column);

                    if (square != null && square.Piece == null)
                    {
                        legalSquare.Add(square);
                    }
                }

                //Cattura in diagonale
                square = board.GetSquare(Square.Row + (Set * 1), Square.Column + 1);

                if (square != null && square.Piece != null && square.Piece.Set != Set)
                {
                    legalSquare.Add(square);
                }

                square = board.GetSquare(Square.Row + (Set * 1), Square.Column - 1);

                if (square != null && square.Piece != null && square.Piece.Set != Set)
                {
                    legalSquare.Add(square);
                }

            }

            return legalSquare;

        }
    }
}
