using UnityEngine;

namespace SoftBoiledGames.UnityXtensions.Rigidbody
{
    public static class Rigidbody2DExtensions
    {
        /// <summary>
        /// Changes the direction of a rigidbody without changing its speed.
        /// </summary>
        /// <param name="rb2d">.</param>
        /// <param name="newDirection">.</param>
        public static void ChangeDirection(this Rigidbody2D rb2d, Vector2 newDirection)
        {
            rb2d.velocity = newDirection * rb2d.velocity.magnitude;
        }
    }
}
