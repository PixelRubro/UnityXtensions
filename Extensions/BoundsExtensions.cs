using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YoukaiFox.UnityExtensions
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
    }
}