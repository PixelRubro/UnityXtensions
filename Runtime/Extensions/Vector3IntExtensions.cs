using UnityEngine;

namespace PixelRouge.UnityXtensions
{
    public static class Vector3IntExtensions 
    {
        // Author: https://github.com/mminer/unity-extensions
        /// <summary>
        /// Converts a Vector3Int struct to a Vector3.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector3 struct.</returns>
        public static Vector3 ToVector3(this Vector3Int vector)
        {
            return new Vector3(
                System.Convert.ToSingle(vector.x),
                System.Convert.ToSingle(vector.y),
                System.Convert.ToSingle(vector.z)
            );
        }
    }
}
