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

        public bool HasWinner { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player CurrentPlayer { get; set; }

        public Board Board { get; set; }

        private Game()
        {
            HasWinner = false;
            Board = Board.Instance;
            Player1 = new Player(true, Board.Pieces.Where(p=>p.White).ToList());
            Player2 = new Player(false, Board.Pieces.Where(p => !p.White).ToList());

            //White moves first
            CurrentPlayer = Player1;
        }

        public bool MakeAMove(Piece piece, Square square)
        {
            bool moved = false;

            if (!HasWinner)
            {
                Move? move = CurrentPlayer.MoveAPiece(Board, piece, square);

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
            CurrentPlayer = CurrentPlayer.White ? Player2 : Player1;
        }
    }
}
