namespace YoukaiFox.UnityExtensions
{
    public static class Vector3IntExtensions 
    {
        /// <summary>
        /// Converts a Vector3Int struct to a Vector3.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector3 struct.</returns>
        public static UnityEngine.Vector3 ToVector3(this UnityEngine.Vector3Int vector)
        {
            return new UnityEngine.Vector3(
                System.Convert.ToSingle(vector.x),
                System.Convert.ToSingle(vector.y),
                System.Convert.ToSingle(vector.z)
            );
        }
    }
}
