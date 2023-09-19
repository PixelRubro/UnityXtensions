using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelRouge.UnityXtensions
{
    public class Vector2Wrapper
    {
        public static Vector2 UpperLeft => new Vector2(-1f, 1f).normalized;

        public static Vector2 UpperRight => new Vector2(1f, 1f).normalized;

        public static Vector2 LowerLeft => new Vector2(-1f, -1f).normalized;

        public static Vector2 LowerRight => new Vector2(1f, -1f).normalized;
    }
}
