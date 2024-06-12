using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Constants
    {
        #region Pieces

        public const string PIECES_PAWN = "Pawn";

        public const string PIECES_ROOK = "Rook";

        public const string PIECES_KNIGHT = "Knight";

        public const string PIECES_BISHOP = "Bishop";

        public const string PIECES_QUEEN = "Queen";

        public const string PIECES_KING = "King";

        #endregion

        #region Images

        public const string FOLDER_IMAGES = @"\Images";

        #region White

        public const string IMAGES_PAWN = FOLDER_IMAGES + @"\pawn.png";
        public const string IMAGES_ROOK = FOLDER_IMAGES + @"\rook.png";
        public const string IMAGES_KNIGHT = FOLDER_IMAGES + @"\knight.png";
        public const string IMAGES_BISHOP = FOLDER_IMAGES + @"\bishop.png";
        public const string IMAGES_QUEEN = FOLDER_IMAGES + @"\queen.png";
        public const string IMAGES_KING = FOLDER_IMAGES + @"\king.png";

        #endregion

        #region Black

        public const string IMAGES_PAWN_D = FOLDER_IMAGES + @"\pawn-d.png";
        public const string IMAGES_ROOK_D = FOLDER_IMAGES + @"\rook-d.png";
        public const string IMAGES_KNIGHT_D = FOLDER_IMAGES + @"\knight-d.png";
        public const string IMAGES_BISHOP_D = FOLDER_IMAGES + @"\bishop-d.png";
        public const string IMAGES_QUEEN_D = FOLDER_IMAGES + @"\queen-d.png";
        public const string IMAGES_KING_D = FOLDER_IMAGES + @"\king-d.png";

        #endregion

        #endregion
    }
}
