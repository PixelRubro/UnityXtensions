using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YoukaiFox.UnityExtensions.Transform
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Makes the given game objects children of the transform.
        /// </summary>
        /// <param name="transform">Parent transform.</param>
        /// <param name="children">Children to be parented.</param>
        public static void AddChildren(this UnityEngine.Transform transform, UnityEngine.Transform[] children)
        {
            System.Array.ForEach(children, child => child.transform.parent = transform);
        }

        /// <summary>
        /// Get all the children parented by the transform.
        /// </summary>
        /// <param name="transform">Parent transform.</param>
        /// <returns></returns>
        public static List<UnityEngine.Transform> GetChildren(this UnityEngine.Transform transform)
        {
            var children = new List<UnityEngine.Transform>();

            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i));
            }

            return children;
        }

        /// <summary>
        /// Sets the x component of the transform's position.
        /// </summary>
        /// <param name="value">Value of x.</param>
        public static void SetX(this UnityEngine.Transform transform, float value)
        {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        }

        /// <summary>
        /// Sets the y component of the transform's position.
        /// </summary>
        /// <param name="value">Value of y.</param>
        public static void SetY(this UnityEngine.Transform transform, float value)
        {
            transform.position = new Vector3(transform.position.x, value, transform.position.z);
        }

        /// <summary>
        /// Sets the z component of the transform's position.
        /// </summary>
        /// <param name="value">Value of z.</param>
        public static void SetZ(this UnityEngine.Transform transform, float value)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, value);
        }
    }
}
