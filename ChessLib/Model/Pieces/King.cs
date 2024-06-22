using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class King : Piece
    {
        public King(int id, int set, Square square) : base(id, set, square) { }

        public override Move Move(Board board, Square square)
        {
            var move = base.Move(board, square);

            #region Castling

            if (square.Castling != null)
            {
                var rook = square.Castling.Piece;

                var squareTo = board.Squares[square.Row, square.Column + square.Castling.Side];
                rook.SetSquare(squareTo);

                move.Castling = square.Castling;
            }

            #endregion

            return move;
        }

        public override Square UndoMove(Board board, Move move)
        {
            var square = base.UndoMove(board, move);

            #region Undo castling (arrocco)
            if (move.Castling != null)
            {
                var rook = board.Squares[square.Row, square.Column - move.SquareTo.Side].Piece;
                rook.SetSquare(move.Castling, false);
            }
            #endregion

            return square;
        }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var directions = new List<(int row, int col)> { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) };

            #region Standard moves

            foreach (var (row, col) in directions)
            {
                var square = board.GetSquare(Square.Row + row, Square.Column + col);

                if (square != null && (square.Piece == null || square.Piece.Set != Set))
                {
                    legalSquare.Add(square);
                }
            }

            #endregion

            #region Castling (arrocco)

            if (!Moved)
            {
                var sides = new List<(int side, int dir)>() { (4, Board.QUEENSIDE), (3, Board.KINGSIDE) };

                foreach (var (side, dir) in sides)
                {
                    var square = board.Squares[Square.Row, Square.Column - (side * dir)];

                    if (square.Piece != null && !square.Piece.Moved)
                    {
                        bool add = false;

                        for (int i = 1; i < side && !add; i++)
                        {
                            square = board.Squares[Square.Row, Square.Column - (i * dir)];
                            add = square.Piece != null;
                        }

                        if (!add)
                        {
                            square = board.Squares[Square.Row, Square.Column - (2 * dir)];
                            legalSquare.Add(square);
                        }
                    }
                }
            }

            #endregion

            return legalSquare;
        }
    }
}
