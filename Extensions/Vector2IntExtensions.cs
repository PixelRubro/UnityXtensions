namespace YoukaiFox.UnityExtensions
{
    public static class Vector2IntExtensions 
    {
        /// <summary>
        /// Converts a Vector3Int struct to a Vector3.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector3 struct.</returns>
        public static UnityEngine.Vector2 ToVector2(this UnityEngine.Vector2Int vector)
        {
            return new UnityEngine.Vector2(
                System.Convert.ToSingle(vector.x),
                System.Convert.ToSingle(vector.y)
            );
        }
    }
}
