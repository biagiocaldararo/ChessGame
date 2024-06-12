﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model.Pieces
{
    public class King : Piece
    {
        public King(bool white, Square square) : base(white, square) { }

        public override List<Square> GetLegalSquares()
        {
            throw new NotImplementedException();
        }
    }
}