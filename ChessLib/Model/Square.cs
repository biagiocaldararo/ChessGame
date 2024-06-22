using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib.Model.Pieces;

namespace ChessLib.Model
{
    public class Square
    {
        public Piece Piece { get; set; }
        public int Row { get; }
        public int Column { get; }
        public Move EnPassantMove { get; set; }
        public Square Castling { get; set; }
        public int Side { get; set; }

        public Square(int row, int column, int side)
        {
            Row = row;
            Column = column;
            Side = side;
            EnPassantMove = null;
        }

        public void Add(Piece p, ref List<Piece> pieces)
        {
            Piece = p;
            pieces.Add(p);
        }

        public void RemovePiece() 
        {
            Piece = null;
        }

        public bool Equals(Square square)
        {
            return square != null && Row == square.Row && Column == square.Column;
        }

        public override string ToString()
        {
            return Row + "," + Column;  
        }
    }
}
