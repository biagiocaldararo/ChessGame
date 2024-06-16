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

        public bool FirstMove { get; }

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
            FirstMove = !piece.Moved;
            Check = false;
        }

        public Square Undo()
        {
            
            Piece.Square = SquareFrom;
            SquareFrom.Piece = Piece;

            Piece.Moved = !FirstMove;

            if (CapturedPiece != null)
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
