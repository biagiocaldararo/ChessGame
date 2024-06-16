﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int id, int set, Square square) : base(id, set, square) { }

        public override List<Square> GetLegalSquares(Board board)
        {
            var legalSquare = new List<Square>();

            var directions = new List<(int Row, int Col)> { (1, 1), (1, -1), (-1, 1), (-1, -1) };

            foreach (var d in directions)
            {
                bool stop = false;

                for (int r = Square.Row, c = Square.Column; !stop; r += d.Row, c += d.Col)
                {
                    var square = board.GetSquare(r + d.Row, c + d.Col);

                    if (square != null && (square.Piece == null || square.Piece.Set != Set))
                    {
                        legalSquare.Add(square);
                        stop = square.Piece != null && square.Piece.Set != Set;
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }

            return legalSquare;
        }
    }
}
