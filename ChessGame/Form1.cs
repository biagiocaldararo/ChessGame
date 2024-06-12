using ChessGame.Controls;
using ChessLib.Model;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        #region Layout

        private int SquareSize;

        private int SquareInitLocation_X;

        private int SquareLocation_Y;

        private int SquareLocation_X;

        #endregion

        private Game Game;

        private SquareButton PressedButton;

        private List<SquareButton> Buttons;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SquareSize = Height / 8;
            SquareLocation_Y = Height - SquareSize;
            SquareInitLocation_X = (int)(SquareSize * 2.4);
        }

        private void Btn_NewGame_Click(object sender, EventArgs e)
        {
            Game = Game.Instance;

            CreateChessBoard();

            btn_NewGame.Enabled = false;
            btn_Concede.Visible = true;
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_ClickButton(object sender, EventArgs e)
        {
            var currentButton = (SquareButton)sender;

            //Se clicco la prima volta, evidenzio la casella e attivo le caselle che posso raggiungere
            if (PressedButton == null)
            {
                PressedButton = currentButton;
                PressedButton.BackColor = Color.LightBlue;

                UpdateButtons(true);
            }
            else
            {
                //se clicco la casella che ho selezionato, annullo la selezione e il controllo resta al giocatore corrente
                if (PressedButton.Square.Equals(currentButton.Square))
                {
                    PressedButton.BackColor = (PressedButton.Square.Row + PressedButton.Square.Column) % 2 == 0 ? Color.DarkGray : Color.White;
                    PressedButton = null;
                }
                else
                {
                    Game.MakeAMove(PressedButton.Square.Piece, currentButton.Square);
                    UpdateSquareButton(currentButton);
                }

                UpdateButtons(false);
            }
        }

        private void btn_Concede_Click(object sender, EventArgs e)
        {
            string player = Game.CurrentPlayer.White ? "Player2" : "Player1";
            MessageBox.Show(player + " wins!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void CreateChessBoard()
        {
            for (int i = 0; i < Game.Board.Squares.GetLength(0); i++)
            {
                SquareLocation_X = SquareInitLocation_X;

                for (int j = 0; j < Game.Board.Squares.GetLength(1); j++)
                {
                    Button newButton = CreateSquareButton(Game.Board.Squares[i, j], SquareLocation_X, SquareLocation_Y);
                    Controls.Add(newButton);

                    SquareLocation_X += SquareSize;
                }

                SquareLocation_Y -= SquareSize;
            }

            Buttons = Controls.OfType<SquareButton>().ToList();
        }

        private SquareButton CreateSquareButton(Square square, int x, int y)
        {
            var newButton = new SquareButton(square)
            {
                Square = square,

                Location = new Point(x, y),
                Size = new Size(SquareSize, SquareSize),
                BackColor = (square.Row + square.Column) % 2 == 0 ? Color.DarkGray : Color.White,
                BackgroundImage = square.Piece != null ? GetImage(square.Piece.GetType().Name, square.Piece.White) : null,
                BackgroundImageLayout = ImageLayout.Stretch,
                Enabled = square.Piece != null && square.Piece.White == Game.CurrentPlayer.White,
            };

            newButton.Click += Btn_ClickButton;

            return newButton;
        }

        private static Image GetImage(string type, bool white)
        {
            Image image = null;

            switch (type)
            {
                case Constants.PIECES_PAWN:
                    image = white ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_PAWN)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_PAWN_D);
                    break;
                case Constants.PIECES_ROOK:
                    image = white ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_ROOK)
                      : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_ROOK_D);
                    break;
                case Constants.PIECES_KNIGHT:
                    image = white ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KNIGHT)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KNIGHT_D);
                    break;
                case Constants.PIECES_BISHOP:
                    image = white ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_BISHOP)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_BISHOP_D);
                    break;
                case Constants.PIECES_QUEEN:
                    image = white ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_QUEEN)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_QUEEN_D);
                    break;
                case Constants.PIECES_KING:
                    image = white ? Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KING)
                        : Image.FromFile(Environment.CurrentDirectory + Constants.IMAGES_KING_D);
                    break;
            }

            return image;
        }

        private void UpdateSquareButton(SquareButton squareButton)
        {
            //squareButton.BackgroundImage = PressedButton.BackgroundImage;
            squareButton.BackgroundImage = squareButton.Square.Piece != null ?
                GetImage(squareButton.Square.Piece.GetType().Name, squareButton.Square.Piece.White) : null;

            PressedButton.BackgroundImage = null;
            PressedButton.BackColor = (PressedButton.Square.Row + PressedButton.Square.Column) % 2 == 0 ? Color.DarkGray : Color.White;
            PressedButton = null;

        }

        private void UpdateButtons(bool firstClick)
        {
            foreach (var btn in Buttons)
            {
                btn.Enabled = firstClick ? (PressedButton.Square.Equals(btn.Square) || (btn.Square.Piece == null || btn.Square.Piece.White != Game.CurrentPlayer.White))
                    : (btn.Square.Piece != null && btn.Square.Piece.White == Game.CurrentPlayer.White);
            }
        }
    }
}
