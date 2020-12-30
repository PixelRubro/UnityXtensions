using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class Vector2IntExtensions 
    {
        // Author: https://github.com/mminer/unity-extensions
        /// <summary>
        /// Converts a Vector3Int struct to a Vector3.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector3 struct.</returns>
        public static Vector2 ToVector2(this Vector2Int vector)
        {
            return new Vector2(
                System.Convert.ToSingle(vector.x),
                System.Convert.ToSingle(vector.y)
            );
        }
    }
}
