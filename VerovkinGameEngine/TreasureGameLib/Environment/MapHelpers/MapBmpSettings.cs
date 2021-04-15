using System.Drawing;

namespace TreasureGameLib.Environment.MapHelpers
{
    /// <summary>
    /// Сolor adjustment for bmp image
    /// </summary>
    public class MapBmpSettings
    {
        #region Fields

        public Color Empty { get; set; }

        public Color Common { get; set; }

        public Color Destructible { get; set; }

        public Color Improved { get; set; }

        #endregion
        #region Constructors

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        public MapBmpSettings()
            : this (Color.White, Color.Black, Color.Green, Color.Red)
        { }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="empty">Empty place color on bmp map</param>
        /// <param name="common">Wall color on bmp map</param>
        /// <param name="destructible">Destructible wall color on bmp map</param>
        /// <param name="improved">Improved wall color on bmp map</param>
        public MapBmpSettings(Color empty, Color common, Color destructible, Color improved)
        {
            Empty = empty;
            Common = common;
            Destructible = destructible;
            Improved = improved;
        }

        #endregion
    }
}
