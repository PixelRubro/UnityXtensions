namespace YoukaiFox.UnityExtensions
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Creates a Layer Mask based on the names provided.
        /// </summary>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static UnityEngine.LayerMask Create(this UnityEngine.LayerMask mask, params string[] layerNames)
        {
            return NamesToMask(layerNames);
        }

        /// <summary>
        /// Creates a Layer Mask based on the names provided.
        /// </summary>
        /// <param name="layerNumbers"></param>
        /// <returns></returns>
        public static UnityEngine.LayerMask Create(params int[] layerNumbers)
        {
            return LayerNumbersToMask(layerNumbers);
        }

        /// <summary>
        /// Returns a Layer Mask with the provided layers added.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static UnityEngine.LayerMask AddLayer(this UnityEngine.LayerMask original, params string[] layerNames)
        {
            return original | NamesToMask(layerNames);
        }

        /// <summary>
        /// Returns a Layer Mask with the provided layers removed.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static UnityEngine.LayerMask RemoveLayer(this UnityEngine.LayerMask original, params string[] layerNames)
        {
            UnityEngine.LayerMask invertedOriginal = ~original;
            return ~(invertedOriginal | NamesToMask(layerNames));
        }

        /// <summary>
        /// Returns a Layer Mask built with the provided names.
        /// </summary>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        private static UnityEngine.LayerMask NamesToMask(params string[] layerNames)
        {
            UnityEngine.LayerMask resultingMask = (UnityEngine.LayerMask) 0;

            foreach (var name in layerNames)
            {
                resultingMask |= (1 << UnityEngine.LayerMask.NameToLayer(name));
            }

            return resultingMask;
        }

        /// <summary>
        /// Returns a Layer Mask built with the provided layer numbers.
        /// </summary>
        /// <param name="layerNumbers"></param>
        /// <returns></returns>
        private static UnityEngine.LayerMask LayerNumbersToMask(params int[] layerNumbers)
        {
            UnityEngine.LayerMask resultingMask = (UnityEngine.LayerMask) 0;

            foreach (var layer in layerNumbers)
            {
                resultingMask |= (1 << layer);
            }
            return resultingMask;
        }

        /// <summary>
        /// Checks if the Layer Maks has a specific layer by its number.
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layerNumber"></param>
        /// <returns></returns>
        public static bool Contains(this UnityEngine.LayerMask mask, int layerNumber)
        {
            return mask == (mask | (1 << layerNumber));
        }

        /// <summary>
        /// Checks if the Layer Maks has a specific layer by its name.
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layerNumber"></param>
        /// <returns></returns>
        public static bool Contains(this UnityEngine.LayerMask mask, string layerName)
        {
            return mask == (mask | (1 << UnityEngine.LayerMask.NameToLayer(layerName)));
        }
    }
}
