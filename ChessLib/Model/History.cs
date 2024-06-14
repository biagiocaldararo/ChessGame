using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Model
{
    public sealed class History
    {
        #region Singleton stuff
        private static History instance;

        public static History Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new History();
                }
                return instance;
            }
        }
        #endregion

        public List<Move> Moves { get; private set; }

        private History()
        {
            Moves = new List<Move>();
        }

        public Move GetLastMove()
        {
            return Moves.Count > 0 ? Moves[Moves.Count - 1] : null;
        }

        public void RemoveLastMove()
        {
            Moves.RemoveAt(Moves.Count - 1);
        }
    }
}
