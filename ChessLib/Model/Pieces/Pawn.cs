using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Pawn : Piece
    {
        public bool Promoted { get; set; }

        public Pawn(int id, int set, Square square) : base(id, set, square)
        {
            Promoted = false;
        }

        public override Move Move(Board board, Square square)
        {
            var move = base.Move(board, square);

            if (square.EnPassantMove != null)
            {
                square.EnPassantMove.Piece.Captured = true;
                move.CapturedPiece = square.EnPassantMove.Piece;
                square.EnPassantMove.SquareTo.Piece = null;
                square.EnPassantMove = null;

                move.EnPassant = true;
            }

            if (move.Promotion)
            {
                //TODO
            }

            return move;
        }

        public override Square UndoMove(Board board, Move move)
        {
            var square = base.UndoMove(board, move);

            if (move.EnPassant)
            {
                move.CapturedPiece.Captured = false;
                move.CapturedPiece.Square.Piece = move.CapturedPiece;
            }

            return square;
        }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var directions = new List<int>() { 1, -1 };

            if (!Promoted)
            {
                #region Muovi avanti di 1
                var square = board.GetSquare(Square.Row + (Set * 1), Square.Column);

                if (square != null && square.Piece == null)
                {
                    legalSquare.Add(square);
                }
                #endregion

                #region Muovi avanti di 2
                if (!Moved)
                {
                    square = board.GetSquare(Square.Row + (Set * 2), Square.Column);

                    if (square != null && square.Piece == null)
                    {
                        legalSquare.Add(square);
                    }
                }
                #endregion

                #region Cattura in diagonale
                foreach (var d in directions)
                {
                    square = board.GetSquare(Square.Row + (Set * 1), Square.Column + d);

                    if (square != null && square.Piece != null && square.Piece.Set != Set)
                    {
                        legalSquare.Add(square);
                    }
                }
                #endregion

                #region En passant
                foreach (var d in directions)
                {
                    square = board.GetSquare(Square.Row, Square.Column + d);

                    if (square != null && square.Piece != null && square.Piece.Set != Set)
                    {
                        var lastMove = board.History.GetLastMove();

                        if (lastMove != null && lastMove.First && square.Piece.Equals(lastMove.Piece))
                        {
                            square = board.GetSquare(Square.Row + 1, Square.Column + d);
                            square.EnPassantMove = lastMove;

                            legalSquare.Add(square);
                            break;
                        }
                    }
                } 
                #endregion
            }

            return legalSquare;

        }
    }
}
