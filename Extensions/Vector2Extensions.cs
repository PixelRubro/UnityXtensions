using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Finds the position closest to the current one.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        public static UnityEngine.Vector2 GetClosest(this UnityEngine.Vector2 position, params UnityEngine.Vector2[] additionalPositions)
        {
            var closest = UnityEngine.Vector2.zero;
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
