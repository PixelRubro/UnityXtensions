using UnityEngine.EventSystems;
using UnityEngine;

namespace PixelSparkStudio.UnityXtensions
{
    public static class PointerEventDataExtensions 
    {
        // Author: github.com/SanBen/UnityExtensions (Adapted).
        /// <summary>
        /// Converts the pointer position to world position.
        /// </summary>
        /// <returns></returns>
        public static Vector3 WorldPosition(this PointerEventData self)
        {
            return self.pointerCurrentRaycast.worldPosition;
        }
    }
}