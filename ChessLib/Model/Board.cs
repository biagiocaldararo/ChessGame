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
        public const int WHITE = 1;
        public const int BLACK = -1;

        public Square[,] Squares { get; set; }

        public List<Piece> Pieces { get; set; }

        public History History { get; set; }

        public bool EnPassant { get; set; }

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
            Squares[0, 0].Add(new Rook(1, WHITE, Squares[0, 0]), ref pieces);
            Squares[0, 1].Add(new Knight(2, WHITE, Squares[0, 1]), ref pieces);
            Squares[0, 2].Add(new Bishop(3, WHITE, Squares[0, 2]), ref pieces);
            Squares[0, 3].Add(new Queen(4, WHITE, Squares[0, 3]), ref pieces);
            Squares[0, 4].Add(new King(5, WHITE, Squares[0, 4]), ref pieces);
            Squares[0, 5].Add(new Bishop(6, WHITE, Squares[0, 5]), ref pieces);
            Squares[0, 6].Add(new Knight(7, WHITE, Squares[0, 6]), ref pieces);
            Squares[0, 7].Add(new Rook(8, WHITE, Squares[0, 7]), ref pieces);

            Squares[1, 0].Add(new Pawn(9, WHITE, Squares[1, 0]), ref pieces);
            Squares[1, 1].Add(new Pawn(10, WHITE, Squares[1, 1]), ref pieces);
            Squares[1, 2].Add(new Pawn(11, WHITE, Squares[1, 2]), ref pieces);
            Squares[1, 3].Add(new Pawn(12, WHITE, Squares[1, 3]), ref pieces);
            Squares[1, 4].Add(new Pawn(13, WHITE, Squares[1, 4]), ref pieces);
            Squares[1, 5].Add(new Pawn(14, WHITE, Squares[1, 5]), ref pieces);
            Squares[1, 6].Add(new Pawn(15, WHITE, Squares[1, 6]), ref pieces);
            Squares[1, 7].Add(new Pawn(16, WHITE, Squares[1, 7]), ref pieces);
            #endregion

            #region Black pieces
            Squares[6, 0].Add(new Pawn(17, BLACK, Squares[6, 0]), ref pieces);
            Squares[6, 1].Add(new Pawn(18, BLACK, Squares[6, 1]), ref pieces);
            Squares[6, 2].Add(new Pawn(19, BLACK, Squares[6, 2]), ref pieces);
            Squares[6, 3].Add(new Pawn(20, BLACK, Squares[6, 3]), ref pieces);
            Squares[6, 4].Add(new Pawn(21, BLACK, Squares[6, 4]), ref pieces);
            Squares[6, 5].Add(new Pawn(22, BLACK, Squares[6, 5]), ref pieces);
            Squares[6, 6].Add(new Pawn(23, BLACK, Squares[6, 6]), ref pieces);
            Squares[6, 7].Add(new Pawn(24, BLACK, Squares[6, 7]), ref pieces);

            Squares[7, 0].Add(new Rook(25, BLACK, Squares[7, 0]), ref pieces);
            Squares[7, 1].Add(new Knight(26, BLACK, Squares[7, 1]), ref pieces);
            Squares[7, 2].Add(new Bishop(27, BLACK, Squares[7, 2]), ref pieces);
            Squares[7, 3].Add(new Queen(28, BLACK, Squares[7, 3]), ref pieces);
            Squares[7, 4].Add(new King(29, BLACK, Squares[7, 4]), ref pieces);
            Squares[7, 5].Add(new Bishop(30, BLACK, Squares[7, 5]), ref pieces);
            Squares[7, 6].Add(new Knight(31, BLACK, Squares[7, 6]), ref pieces);
            Squares[7, 7].Add(new Rook(32, BLACK, Squares[7, 7]), ref pieces);
            #endregion

            Pieces = pieces;
            #endregion

            EnPassant = false;   

            History = History.Instance;
        }

        public Move Move(Piece piece, Square square, int set)
        {
            Move move = null;

            if (set == piece.Set)
            {
                move = piece.Move(square);

                if (square.Piece != null)
                {
                    square.Piece.Captured = true;
                    move.CapturedPiece = square.Piece;
                }

                SetSquare(piece, square);

            }

            return move;
        }

        public Square GetSquare(int row, int col)
        {
            Square square = null;

            if (row >= 0 && row < DIM && col >= 0 && col < DIM)
            {
                square = Squares[row, col];
            }

            return square;
        }

        public void SetSquare(Piece piece, Square square)
        {
            var squareFrom = piece.Square;

            piece.Square = square;
            piece.Moved = true;

            squareFrom.Piece = null;
            piece.Square.Piece = piece;
        }

        public void SetSquare(Move move)
        {
            var squareFrom = move.SquareFrom;
            move.Piece.Square = squareFrom;

            move.SquareTo.Piece = null;
            move.SquareFrom.Piece = move.Piece;
        }
    }
}
