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

        public override Move Move(Square square)
        {
            var move = base.Move(square);

            if (square.Castling)
            {

            }

            return move;
        }

        public override Square UndoMove(Board board, Move move)
        {
            var square = base.UndoMove(board, move);

            if (move.Castling)
            {

            }

            return square;
        }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var directions = new List<(int Row, int Col)> { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) };

            #region Standard moves
            foreach (var d in directions)
            {
                var square = board.GetSquare(Square.Row + d.Row, Square.Column + d.Col);

                if (square != null && (square.Piece == null || square.Piece.Set != Set))
                {
                    legalSquare.Add(square);
                }
            }
            #endregion

            #region Castling (Arrocco)

            //Dal lato della regina: 4 - Dal lato della re: 3
            if (!Moved)
            {
                var sides = new List<(int Side, int Dir)>() { (4, -1), (3, 1) };

                foreach (var s in sides)
                {
                    var square = board.Squares[Square.Row, Square.Column + (s.Side * s.Dir)];

                    if (square.Piece != null && !square.Piece.Moved)
                    {
                        bool add = false;

                        for (int i = 1; i < s.Side && !add; i++)
                        {
                            square = board.Squares[Square.Row, Square.Column + (s.Dir * i)];
                            add = square.Piece != null;
                        }

                        if (!add)
                        {
                            square = board.Squares[Square.Row, Square.Column + (s.Dir * 2)];
                            square.Castling = true;

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
