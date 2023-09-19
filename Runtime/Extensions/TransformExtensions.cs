using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelRouge.UnityXtensions
{
    public static class TransformExtensions
    {
        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Set the given transforms as children of the transform.
        /// </summary>
        /// <param name="self">Parent transform.</param>
        /// <param name="children">Children to be parented.</param>
        public static void AddChildren(this Transform self, params Transform[] children)
        {
            foreach (Transform child in children)
            {
                child.SetParent(self, false);
            }
        }

        // Author: Vermillion Vanguard Studio
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

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Sets the X value of the transform's position.
        /// </summary>
        /// <param name="value">New X value.</param>
        /// <param name="isLocal">Indicates if it should be treated like local position.</param>
        public static void SetWorldX(this Transform self, float value, bool isLocal = false)
        {
            if (isLocal)
                self.localPosition = new Vector3(value, self.localPosition.y, self.localPosition.z);
            else
                self.position = new Vector3(value, self.position.y, self.position.z);
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Sets the Y value of the transform's position.
        /// </summary>
        /// <param name="value">New Y value.</param>
        /// <param name="isLocal">Indicates if it should be treated like local position.</param>
        public static void SetWorldY(this Transform self, float value, bool isLocal = false)
        {
            if (isLocal)
                self.localPosition = new Vector3(self.localPosition.x, value, self.localPosition.z);
            else
                self.position = new Vector3(self.position.x, value, self.position.z);
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Sets the Z value of the transform's position.
        /// </summary>
        /// <param name="value">New Z valuez.</param>
        /// <param name="isLocal">Indicates if it should be treated like local position.</param>
        public static void SetWorldZ(this Transform self, float value, bool isLocal = false)
        {
            if (isLocal)
                self.localPosition = new Vector3(self.localPosition.x, self.localPosition.y, value);
            else
                self.position = new Vector3(self.position.x, self.position.y, value);
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Reset the transform's position to (0, 0, 0).
        /// </summary>
        /// <param name="isLocal">Indicates if it should be treated like local position.</param>
        public static void ResetPosition(this Transform self, bool isLocal = false)
        {
            if (isLocal)
                self.localPosition = Vector3.zero;
            else
                self.position = Vector3.zero;
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Reset the transform's rotation to identity.
        /// </summary>
        /// <param name="isLocal">Indicates if it should be treated like local rotation.</param>
        public static void ResetRotation(this Transform self, bool isLocal = false)
        {
            if (isLocal)
                self.localRotation = Quaternion.identity;
            else
                self.rotation = Quaternion.identity;
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Reset the transform's scale to (1, 1, 1).
        /// </summary>
        public static void ResetScale(this Transform self)
        {
            self.localScale = Vector3.one;
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Reset the transform's position, rotation and scale.
        /// </summary>
        /// <param name="isLocal">Indicates if it should be treated locally.</param>
        public static void Reset(this Transform self, bool isLocal = false)
        {
            self.ResetPosition(isLocal);
            self.ResetRotation(isLocal);
            self.ResetScale();
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Teleport the transform to a direction at a speed.
        /// </summary>
        public static void Teleport(this Transform self, Vector2 direction, float speed)
        {
            self.Translate(direction * speed * Time.deltaTime);
        }

        // Author: Vermillion Vanguard Studio
        /// <summary>
        /// Teleport the transform to a direction at a speed.
        /// </summary>
        public static void Teleport(this Transform self, Vector3 direction, float speed)
        {
            self.Translate(direction * speed * Time.deltaTime);
        }

        // Author: github.com/dracolytch/DracoSoftwareExtensionsForUnity
        /// <summary>
        /// Instantly look away from a target Vector3.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static void LookAwayFrom(this Transform self, Vector3 target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }

        // Author: github.com/dracolytch/DracoSoftwareExtensionsForUnity
        /// <summary>
        /// Instantly look away from a target transform.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The target transform to look away from.</param>
        public static void LookAwayFrom(this Transform self, Transform target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }

        // Author: github.com/dracolytch/DracoSoftwareExtensionsForUnity
        /// <summary>
        /// Find the rotation to look away from a target Vector3.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The target transform to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, Vector3 target)
        {
            return Quaternion.LookRotation(self.position - target);
        }

        // Author: github.com/dracolytch/DracoSoftwareExtensionsForUnity
        /// <summary>
        /// Find the rotation to look away from a target transform.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The target transform to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, Transform target)
        {
            return GetLookAwayFromRotation(self, target.position);
        }

        // Author: github.com/SanBen/UnityExtensions
        /// <summary>
        /// Forces the transform to face a camera.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="camera"></param>
        public static void BillboardRotate(this Transform self, Camera camera)
        {
            self.rotation = camera.transform.rotation;
        }

        // Author: github.com/SanBen/UnityExtensions
        /// <summary>
        /// Gets the full path to a Transform.
        /// </summary>
        /// <returns>The path.</returns>
        /// <param name="self">Transform.</param>
        public static string Path(this Transform self, Transform topLevel, bool includeTopLevel)
        {
            if (self.parent == null || self == topLevel)
            {
                if (includeTopLevel)
                {
                    return $"/{self.name}";
                }
                else
                {
                    return string.Empty;
                }
            }
            return $"{self.parent.Path(topLevel, includeTopLevel)}/{self.name}";
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

        /// <summary>
        /// Tranforms an object's position to give the effect of a shake. Must be called from "StartCoroutine" within a Monobehaviour 
        /// </summary>
        /// <param name="self">the GameObject to be shaken.</param>
        /// <param name="shakeDuration">The duration that the shake should occur for.</param>
        /// <param name="shakeIntensity">The max distance from the origin point the shake can move the object to. Sensible range between 0.01f and 1f.</param>
        /// <param name="shakeSpeed">The frequency with which a new position is assigned. Use Time.Deltatime for new shake position every frame.</param>
        /// <returns></returns>
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
