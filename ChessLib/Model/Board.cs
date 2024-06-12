using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib.Model.Pieces;

namespace ChessLib.Model
{
    public sealed class Board
    {
        #region Singleton stuff
        private static Board instance;

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Board();
                }
                return instance;
            }
        }
        #endregion

        public const int DIM = 8;

        public Square[,] Squares { get; set; }

        public List<Piece> Pieces { get; set; }

        private Board()
        {
            #region Create squares
            Squares = new Square[DIM, DIM];

            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    Squares[i, j] = new Square(i, j);
                }
            }
            #endregion

            #region Set pieces
            var pieces = new List<Piece>();

            #region White pieces
            Squares[0, 0].Add(new Rook(true, Squares[0, 0]), ref pieces);
            Squares[0, 1].Add(new Knight(true,Squares[0, 1]), ref pieces);
            Squares[0, 2].Add(new Bishop(true, Squares[0, 2]), ref pieces);
            Squares[0, 3].Add(new Queen(true,Squares[0, 3]), ref pieces);
            Squares[0, 4].Add(new King(true, Squares[0, 4]), ref pieces);
            Squares[0, 5].Add(new Bishop(true, Squares[0, 5]), ref pieces);
            Squares[0, 6].Add(new Knight(true, Squares[0, 6]), ref pieces);
            Squares[0, 7].Add(new Rook(true, Squares[0, 7]), ref pieces);

            Squares[1, 0].Add(new Pawn(true, Squares[1, 0]), ref pieces);
            Squares[1, 1].Add(new Pawn(true, Squares[1, 1]), ref pieces);
            Squares[1, 2].Add(new Pawn(true, Squares[1, 2]), ref pieces);
            Squares[1, 3].Add(new Pawn(true, Squares[1, 3]), ref pieces);
            Squares[1, 4].Add(new Pawn(true, Squares[1, 4]), ref pieces);
            Squares[1, 5].Add(new Pawn(true, Squares[1, 5]), ref pieces);
            Squares[1, 6].Add(new Pawn(true, Squares[1, 6]), ref pieces);
            Squares[1, 7].Add(new Pawn(true, Squares[1, 7]), ref pieces);
            #endregion

            #region Black pieces
            Squares[6, 0].Add(new Pawn(false, Squares[6, 0]), ref pieces);
            Squares[6, 1].Add(new Pawn(false, Squares[6, 1]), ref pieces);
            Squares[6, 2].Add(new Pawn(false, Squares[6, 2]), ref pieces);
            Squares[6, 3].Add(new Pawn(false, Squares[6, 3]), ref pieces);
            Squares[6, 4].Add(new Pawn(false, Squares[6, 4]), ref pieces);
            Squares[6, 5].Add(new Pawn(false, Squares[6, 5]), ref pieces);
            Squares[6, 6].Add(new Pawn(false, Squares[6, 6]), ref pieces);
            Squares[6, 7].Add(new Pawn(false, Squares[6, 7]), ref pieces);

            Squares[7, 0].Add(new Rook(false, Squares[7, 0]), ref pieces);
            Squares[7, 1].Add(new Knight(false, Squares[7, 1]), ref pieces);
            Squares[7, 2].Add(new Bishop(false, Squares[7, 2]), ref pieces);
            Squares[7, 3].Add(new Queen(false, Squares[7, 3]), ref pieces);
            Squares[7, 4].Add(new King(false, Squares[7, 4]), ref pieces);
            Squares[7, 5].Add(new Bishop(false, Squares[7, 5]), ref pieces);
            Squares[7, 6].Add(new Knight(false, Squares[7, 6]), ref pieces);
            Squares[7, 7].Add(new Rook(false, Squares[7, 7]), ref pieces);
            #endregion

            Pieces = pieces; 
            #endregion
        }

        public Move? Move(Piece piece, Square square, bool white)
        {
            Move? move = null;

            if (white == piece.White)
            {
                move = new Move(piece, square);

                if (square.Piece != null)
                {
                    square.Piece.Captured = true;
                }

                SetSquare(piece, square);

            }

            return move;
        }

        public void SetSquare(Piece piece, Square square)
        {
            piece.Square.RemovePiece();
            piece.SetSquare(square);
            piece.Square.Piece = piece;
        }
    }
}
