using UnityEngine;

namespace SoftBoiledGames.UnityXtensions
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

        public static Vector3 GetNearbyRandomPosition(this Vector3 self, float radius)
        {
            float randomX = Random.Range(-radius, radius);
            float randomY = Random.Range(-radius, radius);
            float randomZ = Random.Range(-radius, radius);
            return new Vector3(self.x + randomX, self.y + randomY, self.z + randomZ);
        }

        public static Vector3 Clamp(this Vector3 self, float maxLength)
        {
            var magnitude = self.magnitude;

            if (magnitude <= maxLength)
            {
                return self;
            }

            return self.normalized * maxLength;
        }

        /// <summary>
        /// Get a random Vector3 with a length of 1.
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetRandomNormalizedVector3()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}
