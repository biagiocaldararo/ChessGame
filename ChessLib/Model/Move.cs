using ChessLib.Model.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model
{
    public class Move
    {
        public Piece Piece { get; }

        public Square SquareFrom { get; }

        public Square SquareTo { get; }

        public Piece CapturedPiece { get; }

        public bool Check { get; private set; }

        public bool Capture
        {
            get
            {
                return CapturedPiece != null;
            }
        }

        public bool CheckMate
        {
            get
            {
                return false; //TODO
            }
        }

        public Move(Piece piece, Square squareTo)
        {
            Piece = piece;
            SquareFrom = piece.Square;
            SquareTo = squareTo;
            Check = false;
        }
    }
}
