using UnityEngine;

namespace SoftBoiledGames.UnityXtensions
{
    public static class RigidbodyExtensions
    {
        /// <summary>
        /// Changes the direction of a rigidbody without changing its speed.
        /// </summary>
        /// <param name="rb">.</param>
        /// <param name="newDirection">.</param>
        public static void ChangeDirection(this UnityEngine.Rigidbody rb, Vector3 newDirection)
        {
            rb.velocity = newDirection * rb.velocity.magnitude;
        }
    }
}
