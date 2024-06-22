using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public abstract class Piece
    {
        public int Id { get; set; }

        public int Set { get; set; }

        public Square Square { get; set; }

        public bool Moved { get; set; }

        public bool Captured { get; set; }

        public Piece(int id, int set, Square square)
        {
            Id = id;
            Set = set;
            Square = square;
            Moved = false;
            Captured = false;
        }

        public abstract List<Square> GetLegalSquares(Board board);

        public virtual Move Move(Board board, Square square)
        {
            var move =  new Move(this, square);

            if (square.Piece != null)
            {
                square.Piece.Captured = true;
                move.CapturedPiece = square.Piece;
            }

            return move;
        }

        public virtual Square UndoMove(Board board, Move move)
        {
            return move.Undo();
        }

        public void SetSquare(Square square, bool moved = true)
        {
            var squareFrom = Square;

            Square = square;
            Moved = moved;

            squareFrom.Piece = null;
            Square.Piece = this;
        }

        public bool Equals(Piece piece)
        {
            return Id == piece.Id;
        }
    }
}
