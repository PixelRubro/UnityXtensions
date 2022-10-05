using UnityEngine;

namespace SoftBoiledGames.UnityXtensions
{
    public static class ColorExtensions 
    {
        // Origin: Stack Overflow
        /// <summary>
        /// Decides which color from black or white which
        /// contrasts better with this color <paramref name="self"/>.
        /// </summary>
        /// </<seealso cref="http://stackoverflow.com/questions/2241447/make-foregroundcolor-black-or-white-depending-on-background"/>
        public static Color GetContrastingColor(this Color self)
        {
            float colorProduct = self.r * self.r * 0.241f + self.g * self.g * 0.691f + self.b * self.b * 0.068f;

            if (Mathf.Sqrt(colorProduct) > 128f)
                return Color.black;

            return Color.white;
        }
    }
}