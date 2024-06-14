using ChessLib.Model.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model
{
    public sealed class Game
    {
        #region Singleton stuff
        private static Game instance;

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return instance;
            }
        }
        #endregion

        public Board Board { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player CurrentPlayer { get; set; }

        public List<Move> History { get; set; }

        public bool HasWinner { get; set; }

        private Game()
        {
            Board = Board.Instance;

            Player1 = new Player(Board.WHITE, Board.Pieces.Where(p => p.Set == Board.WHITE).ToList());
            Player2 = new Player(Board.BLACK, Board.Pieces.Where(p => p.Set == Board.BLACK).ToList());
            CurrentPlayer = Player1; //White moves first

            History = new List<Move>();

            HasWinner = false;
        }

        public bool MakeAMove(Piece piece, Square square)
        {
            bool moved = false;

            if (!HasWinner)
            {
                Move move = CurrentPlayer.MoveAPiece(Board, piece, square);

                if (move != null)
                {
                    if (move.CheckMate)
                    {
                        HasWinner = true;
                    }
                    else
                    {
                        NextPlayerTurn();
                    }
                }
            }

            return moved;
        }

        private void NextPlayerTurn()
        {
            CurrentPlayer = CurrentPlayer.Set == Board.WHITE ? Player2 : Player1;
        }
    }
}
