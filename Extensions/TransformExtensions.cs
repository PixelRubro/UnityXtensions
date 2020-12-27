using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Makes the given game objects children of the transform.
        /// </summary>
        /// <param name="self">Parent transform.</param>
        /// <param name="children">Children to be parented.</param>
        public static void AddChildren(this Transform self, Transform[] children)
        {
            System.Array.ForEach(children, child => child.transform.parent = self);
        }

        /// <summary>
        /// Get all the children parented by the transform.
        /// </summary>
        /// <param name="self">Parent transform.</param>
        /// <returns></returns>
        public static List<Transform> GetChildren(this Transform self)
        {
            var children = new List<Transform>();

            for (int i = 0; i < self.childCount; i++)
            {
                children.Add(self.GetChild(i));
            }

            return children;
        }

        /// <summary>
        /// Sets the x component of the transform's position.
        /// </summary>
        /// <param name="value">Value of x.</param>
        public static void SetWorldX(this Transform self, float value)
        {
            self.position = new Vector3(value, self.position.y, self.position.z);
        }

        /// <summary>
        /// Sets the y component of the transform's position.
        /// </summary>
        /// <param name="value">Value of y.</param>
        public static void SetWorldY(this Transform self, float value)
        {
            self.position = new Vector3(self.position.x, value, self.position.z);
        }

        /// <summary>
        /// Sets the z component of the transform's position.
        /// </summary>
        /// <param name="value">Value of z.</param>
        public static void SetWorldZ(this Transform self, float value)
        {
            self.position = new Vector3(self.position.x, self.position.y, value);
        }

        /// <summary>
        /// Sets the transform local space position x component.
        /// </summary>
        /// <param name="value">Value of x component.</param>
        public static void SetLocalX(this Transform self, float value)
        {
            self.localPosition = new Vector3(value, self.localPosition.y, self.localPosition.z);
        }

        /// <summary>
        /// Sets the transform local space position y component.
        /// </summary>
        /// <param name="value">Value of y component.</param>
        public static void SetLocalY(this Transform self, float value)
        {
            self.localPosition = new Vector3(self.localPosition.x, value, self.localPosition.z);
        }

        /// <summary>
        /// Sets the transform local space position z component.
        /// </summary>
        /// <param name="value">Value of z component.</param>
        public static void SetLocalZ(this Transform self, float value)
        {
            self.localPosition = new Vector3(self.localPosition.x, self.localPosition.y, value);
        }

        /// <summary>
        /// Instantly look away from a target Vector3.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static void LookAwayFrom(this Transform self, Vector3 target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }

        /// <summary>
        /// Instantly look away from a target transform.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The target transform to look away from.</param>
        public static void LookAwayFrom(this Transform self, Transform target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }

        /// <summary>
        /// Find the rotation to look away from a target Vector3.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The target transform to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, Vector3 target)
        {
            return Quaternion.LookRotation(self.position - target);
        }

        /// <summary>
        /// Find the rotation to look away from a target transform.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The target transform to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, Transform target)
        {
            return GetLookAwayFromRotation(self, target.position);
        }
    
        /// <summary>
        /// Tranforms an object's position to give the effect of a shake. Must be called from "StartCoroutine" within a Monobehaviour 
        /// </summary>
        /// <param name="self">the GameObject to be shaken.</param>
        /// <param name="shakeDuration">The duration that the shake should occur for.</param>
        /// <param name="shakeIntensity">The max distance from the origin point the shake can move the object to. Sensible range between 0.01f and 1f.</param>
        /// <param name="shakeSpeed">The frequency with which a new position is assigned. Use Time.Deltatime for new shake position every frame.</param>
        /// <returns></returns>
        public static System.Collections.IEnumerator ApplyShake3D(this Transform self, float shakeDuration,
                                                                  float shakeIntensity, float shakeSpeed)
        {
            float timer = 0f;
            Vector3 shakeValue = Vector3.zero;

            while (timer < shakeDuration)
            {
                //remove the previous shake value
                self.position -= shakeValue;

                //calculate a new shake value and apply it
                shakeValue = new Vector3(Random.Range(-shakeIntensity, shakeIntensity),
                                         Random.Range(-shakeIntensity, shakeIntensity),
                                         Random.Range(-shakeIntensity, shakeIntensity));
                self.position += shakeValue;

                timer += Time.deltaTime;
                yield return new WaitForSeconds(shakeSpeed);
            }
            //correct for any residual shake difference
            self.position -= shakeValue;
        }

        public static IEnumerator ApplyShake2D(this Transform self, float shakeDuration,
                                               float shakeIntensity, float shakeSpeed)
        {
            float timer = 0f;
            Vector2 shakeValue = Vector2.zero;
            Vector3 startPosition = self.transform.position;
            float gObjectZPos = self.transform.position.z;

            while (timer < shakeDuration)
            {
                self.position -= new Vector3(shakeValue.x, shakeValue.y, gObjectZPos);

                shakeValue = new Vector2(Random.Range(-shakeIntensity, shakeIntensity),
                                         Random.Range(-shakeIntensity, shakeIntensity));
                self.position += new Vector3(shakeValue.x, shakeValue.y, gObjectZPos);

                timer += Time.deltaTime;
                yield return new WaitForSeconds(shakeSpeed);
            }
            self.position = startPosition;
        }
    }
}
