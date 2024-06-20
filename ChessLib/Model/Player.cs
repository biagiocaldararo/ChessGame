using ChessLib.Model.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model
{
    public class Player
    {
        public int Set { get; set; }

        public List<Piece> Pieces { get; set; }

        public Player(int set, List<Piece> pieces)
        {
            Set = set;
            Pieces = pieces;
        }

        public Move MoveAPiece(Board board, Piece piece, Square square)
        {
            return board.Move(piece, square, Set);
        }
    }
}
