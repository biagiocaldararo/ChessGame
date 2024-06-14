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
            BackColor = (square.Row + square.Column) % 2 == 0 ? Color.DarkGray : Color.White;
            BackgroundImage = square.Piece != null ? GetImage(square.Piece.GetType().Name, square.Piece.Set) : null;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void Highlight()
        {
            BackColor = Color.LightBlue;
        }

        public void RemoveHighlight()
        {
            BackColor = (Square.Row + Square.Column) % 2 == 0 ? Color.DarkGray : Color.White;
        }

        public void UpdateImage()
        {
            BackgroundImage = Square.Piece != null ? GetImage(Square.Piece.GetType().Name, Square.Piece.Set) : null;
        }

        public static SquareButton GetSquareButtton(List<SquareButton> buttons, Square square)
        {
            SquareButton squareButton = null;

            foreach (var btn in buttons)
            {
                if (btn.Square.Equals(square))
                {
                    squareButton = btn;
                    break;
                }
            }

            return squareButton;
        }

        private static Image GetImage(string type, int set)
        {
            Image image = null;

            switch (type)
            {
                case Constants.PIECES_PAWN:
                    image = set == Board.WHITE ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_PAWN)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_PAWN_D);
                    break;
                case Constants.PIECES_ROOK:
                    image = set == Board.WHITE ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_ROOK)
                      : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_ROOK_D);
                    break;
                case Constants.PIECES_KNIGHT:
                    image = set == Board.WHITE ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KNIGHT)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KNIGHT_D);
                    break;
                case Constants.PIECES_BISHOP:
                    image = set == Board.WHITE ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_BISHOP)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_BISHOP_D);
                    break;
                case Constants.PIECES_QUEEN:
                    image = set == Board.WHITE ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_QUEEN)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_QUEEN_D);
                    break;
                case Constants.PIECES_KING:
                    image = set == Board.WHITE ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KING)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KING_D);
                    break;
            }

            return image;
        }
    }
}
