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

        public virtual Move Move(Square square)
        {
            return new Move(this, square);
        }

        public virtual Square UndoMove(Board board, Move move)
        {
            return move.Undo();
        }

        public bool Equals(Piece piece)
        {
            return Id == piece.Id;
        }
    }
}
