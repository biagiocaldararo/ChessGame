using ChessLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Controls
{
    public class SquareButton : Button
    {
        public Square Square { get; set; }

        public SquareButton(Square square) : base()
        {
            Square = square;
        }
    }
}
