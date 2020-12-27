using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Finds the position closest to the current one.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        public static UnityEngine.Vector3 GetClosest(this UnityEngine.Vector3 position, params UnityEngine.Vector3[] additionalPositions)
        {
            var closest = UnityEngine.Vector3.zero;
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
