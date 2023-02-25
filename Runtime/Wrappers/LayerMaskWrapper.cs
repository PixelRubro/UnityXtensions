using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSparkStudio.UnityXtensions
{
    public class LayerMaskWrapper 
    {
        /// <summary>
        /// Creates a Layer Mask based on the names provided.
        /// </summary>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static LayerMask Create(params string[] layerNames)
        {
            return NamesToMask(layerNames);
        }

        /// <summary>
        /// Creates a Layer Mask based on the names provided.
        /// </summary>
        /// <param name="layerNumbers"></param>
        /// <returns></returns>
        public static LayerMask Create(params int[] layerNumbers)
        {
            return LayerNumbersToMask(layerNumbers);
        }

        /// <summary>
        /// Returns a Layer Mask built with the provided names.
        /// </summary>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static LayerMask NamesToMask(params string[] layerNames)
        {
            LayerMask resultingMask = (LayerMask) 0;

            foreach (var name in layerNames)
            {
                resultingMask |= (1 << LayerMask.NameToLayer(name));
            }

            return resultingMask;
        }

        /// <summary>
        /// Returns a Layer Mask built with the provided layer numbers.
        /// </summary>
        /// <param name="layerNumbers"></param>
        /// <returns></returns>
        public static LayerMask LayerNumbersToMask(params int[] layerNumbers)
        {
            LayerMask resultingMask = (LayerMask) 0;

            foreach (var layer in layerNumbers)
            {
                resultingMask |= (1 << layer);
            }
            return resultingMask;
        }
    }
}
