using ChessGame.Controls;
using ChessLib.Model;
using ChessLib.Model.Pieces;

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

        private SquareButton SelectedButton;

        private List<SquareButton> Buttons;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SquareSize = Height / 8;
            SquareLocation_Y = Height - SquareSize;
            SquareInitLocation_X = Width / 2 - SquareSize * 4;
        }

        private void Btn_NewGame_Click(object sender, EventArgs e)
        {
            Game = Game.Instance;

            CreateChessBoard();

            btn_NewGame.Enabled = false;
            btn_Concede.Visible = true;
            btn_Undo.Visible = true;
            btn_Undo.Enabled = Game.History.Moves.Count > 0;
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_ClickButton(object sender, EventArgs e)
        {
            var currentButton = (SquareButton)sender;

            //Se clicco la prima volta, evidenzio la casella e attivo le caselle che posso raggiungere
            if (SelectedButton == null)
            {
                SelectedButton = currentButton;
                SelectedButton.Highlight();

                UpdateSquareButtons();
            }
            else
            {
                if (!SelectedButton.Square.Equals(currentButton.Square))
                {
                    Game.MakeAMove(SelectedButton.Square.Piece, currentButton.Square);
                    currentButton.UpdateImage();

                    SelectedButton.BackgroundImage = null;
                    SelectedButton.RemoveHighlight();
                }

                SelectedButton.RemoveHighlight();
                UpdateButtons();
                SelectedButton = null;
            }
        }

        private void btn_Concede_Click(object sender, EventArgs e)
        {
            string player = Game.CurrentPlayer.Set == Board.WHITE ? "Player2" : "Player1";
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
                Location = new Point(x, y),
                Size = new Size(SquareSize, SquareSize),
                Enabled = square.Piece != null && square.Piece.Set == Game.CurrentPlayer.Set,
            };

            newButton.Click += Btn_ClickButton;

            return newButton;
        }

        private void UpdateButtons()
        {
            foreach (var btn in Buttons)
            {
                btn.Enabled = btn.Square.Piece != null && btn.Square.Piece.Set == Game.CurrentPlayer.Set;
                btn.UpdateImage();

                if (SelectedButton != null && !SelectedButton.Square.Equals(btn.Square))
                {
                    btn.RemoveHighlight();
                }
            }

            btn_Undo.Enabled = Game.History.Moves.Count > 0;
        }

        private void UpdateSquareButtons()
        {
            var legalSquares = SelectedButton.Square.Piece.GetLegalSquares(Game.Board);

            Buttons.ForEach(btn => btn.Enabled = false);
            SelectedButton.Enabled = true;

            foreach (var square in legalSquares)
            {
                foreach (var btn in Buttons)
                {
                    if (square.Equals(btn.Square))
                    {
                        btn.Enabled = true;
                        btn.BackColor = square.Piece == null ? Color.LightGreen : Color.LightCoral;
                        break;
                    }
                }
            }
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            var square = Game.UndoMove();
            var currentButton = SquareButton.GetSquareButton(Buttons, square);

            currentButton.UpdateImage();
            UpdateButtons();

            btn_Undo.Enabled = Game.History.Moves.Count > 0;
        }
    }
}
