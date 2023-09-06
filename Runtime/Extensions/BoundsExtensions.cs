using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VermillionVanguard.UnityXtensions
{
    public static class BoundsExtensions
    {
        /// <summary>
        /// Checks if <paramref name="bounds"/> is contained by the bounds <paramref name="self"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bounds"></param>
        public static bool ContainsBounds(this Bounds self, Bounds bounds)
        {
            return self.Contains(bounds.min) && self.Contains(bounds.max);
        }

        /// <summary>
        /// Checks if <paramref name="bounds"/> is contained by the bounds
        /// <paramref name="self"/> horizontally.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bounds"></param>
        public static bool ContainsHorizontalBounds(this Bounds self, Bounds bounds)
        {
            return self.min.x < bounds.min.x && self.max.x > bounds.max.x;
        }

        /// <summary>
        /// Checks if <paramref name="bounds"/> is contained by the bounds
        /// <paramref name="self"/> vertically.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bounds"></param>
        public static bool ContainsVerticalBounds(this Bounds self, Bounds bounds)
        {
            return self.min.y < bounds.min.y && self.max.y > bounds.max.y;
        }
    }
}