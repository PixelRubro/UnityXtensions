using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class Vector2Extensions
    {
        // Author: https://github.com/mminer/unity-extensions
        /// <summary>
        /// Finds the position closest to the current one.
        /// </summary>
        /// <param name="self">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        public static Vector2 GetClosest(this Vector2 self, params Vector2[] points)
        {
            var closest = Vector2.zero;
            var shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in points)
            {
                var distance = (self - otherPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }

        public static float AngleToVectorInRads(this Vector2 self, Vector2 vectorTo)
        {
            return Mathf.Atan2(vectorTo.y - self.y, vectorTo.x - self.x);
        }

        public static float AngleToInDegrees(this Vector2 self, Vector2 vectorTo)
        {
            return (AngleToVectorInRads(self, vectorTo) * 180 / Mathf.PI) + 180;
        }
    }
}
