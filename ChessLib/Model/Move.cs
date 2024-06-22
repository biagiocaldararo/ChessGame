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
        public Piece CapturedPiece { get; set; }
        public bool First { get; }
        public bool EnPassant { get; set; }
        public Square Castling { get; set; }
        public bool Check { get; set; }
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
            First = !piece.Moved;
            Check = false;
            EnPassant = false;
        }

        public Square Undo()
        {
            Piece.Square = SquareFrom;
            SquareFrom.Piece = Piece;

            Piece.Moved = !First;

            if (CapturedPiece != null && !EnPassant)
            {
                CapturedPiece.Captured = false;
                SquareTo.Piece = CapturedPiece;
            }
            else
            {
                SquareTo.Piece = null;
            }

            return SquareFrom;
        }
    }
}
