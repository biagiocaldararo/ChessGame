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

        public override Move Move(Square square)
        {
            var move = base.Move(square);

            return move;
        }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            if (!Promoted)
            {
                //Muovi in avanti di 1
                var square = board.GetSquare(Square.Row + (Set * 1), Square.Column);

                if (square != null && square.Piece == null)
                {
                    legalSquare.Add(square);
                }

                //Muovi in avanti di 2 se mai mosso
                if (!Moved)
                {
                    square = board.GetSquare(Square.Row + (Set * 2), Square.Column);

                    if (square != null && square.Piece == null)
                    {
                        legalSquare.Add(square);
                    }
                }

                //Cattura in diagonale
                square = board.GetSquare(Square.Row + (Set * 1), Square.Column + 1);

                if (square != null && square.Piece != null && square.Piece.Set != Set)
                {
                    legalSquare.Add(square);
                }

                square = board.GetSquare(Square.Row + (Set * 1), Square.Column - 1);

                if (square != null && square.Piece != null && square.Piece.Set != Set)
                {
                    legalSquare.Add(square);
                }

                //EnPassant

                square = board.GetSquare(Square.Row, Square.Column + 1);

                if (square != null && square.Piece != null && square.Piece.Set != Set)
                {
                    var lastMove = board.History.GetLastMove();

                    if (lastMove != null && lastMove.FirstMove && square.Piece.Equals(lastMove.Piece))
                    {
                        square = board.GetSquare(Square.Row + 1, Square.Column + 1);
                        square.EnPassant = true;

                        legalSquare.Add(square);
                    }
                }

                square = board.GetSquare(Square.Row, Square.Column - 1);

                if (square != null && square.Piece != null && square.Piece.Set != Set)
                {
                    var lastMove = board.History.GetLastMove();

                    if (lastMove != null && lastMove.FirstMove && square.Piece.Equals(lastMove.Piece))
                    {
                        square = board.GetSquare(Square.Row + 1, Square.Column - 1);
                        square.EnPassant = true;

                        legalSquare.Add(square);
                    }
                }

            }

            return legalSquare;

        }
    }
}
