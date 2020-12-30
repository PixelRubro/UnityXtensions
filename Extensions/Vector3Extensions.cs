using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class Vector3Extensions
    {
        // Author: https://github.com/mminer/unity-extensions
        /// <summary>
        /// Finds the position closest to the current one.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        public static Vector3 GetClosest(this Vector3 position, params Vector3[] additionalPositions)
        {
            var closest = Vector3.zero;
            var shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in additionalPositions)
            {
                var distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }
    }
}
