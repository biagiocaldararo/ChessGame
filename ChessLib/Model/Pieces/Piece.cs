using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public abstract class Piece
    {
        public int Set { get; set; }

        public Square Square { get; set; }

        public bool Moved { get; set; }

        public bool Captured { get; set; }

        public Piece(int set, Square square)
        {
            Set = set;
            Square = square;
            Moved = false;
            Captured = false;
        }

        public abstract List<Square> GetLegalSquares(Board board);

        public virtual Square UndoMove(Board board, Move move)
        {
            Square = move.SquareFrom;

            if (move.CapturedPiece != null) 
            {
                move.CapturedPiece.Captured = false;
            }

            board.SetSquare(this, Square);

            return Square;
        }

        public void SetSquare(Square square)
        {
            Square = square;
            Moved = true;
        }
    }
}
