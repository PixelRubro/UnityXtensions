using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Creates a Layer Mask based on the names provided.
        /// </summary>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static LayerMask Create(this LayerMask self, params string[] layerNames)
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
        /// Returns a Layer Mask with the provided layers added.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static LayerMask AddLayer(this LayerMask self, params string[] layerNames)
        {
            return self | NamesToMask(layerNames);
        }

        /// <summary>
        /// Returns a Layer Mask with the provided layers removed.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static LayerMask RemoveLayer(this LayerMask self, params string[] layerNames)
        {
            LayerMask invertedOriginal = ~self;
            return ~(invertedOriginal | NamesToMask(layerNames));
        }

        /// <summary>
        /// Returns a Layer Mask built with the provided names.
        /// </summary>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        private static LayerMask NamesToMask(params string[] layerNames)
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
        private static LayerMask LayerNumbersToMask(params int[] layerNumbers)
        {
            LayerMask resultingMask = (LayerMask) 0;

            foreach (var layer in layerNumbers)
            {
                resultingMask |= (1 << layer);
            }
            return resultingMask;
        }

        /// <summary>
        /// Checks if the Layer Maks has a specific layer by its number.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="layerNumber"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask self, int layerNumber)
        {
            return self == (self | (1 << layerNumber));
        }

        /// <summary>
        /// Checks if the Layer Maks has a specific layer by its name.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="layerNumber"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask self, string layerName)
        {
            return self == (self | (1 << LayerMask.NameToLayer(layerName)));
        }
    }
}
