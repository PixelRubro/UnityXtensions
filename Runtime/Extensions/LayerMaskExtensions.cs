using UnityEngine;

namespace PixelRouge.UnityXtensions
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Returns a Layer Mask with the provided layers added.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="layerNames"></param>
        /// <returns></returns>
        public static LayerMask AddLayer(this LayerMask self, params string[] layerNames)
        {
            return self | LayerMaskWrapper.NamesToMask(layerNames);
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
            return ~(invertedOriginal | LayerMaskWrapper.NamesToMask(layerNames));
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

        //Author:  Philip Pierce
        public static LayerMask Inverse(this LayerMask original)
        {
            return ~original;
        }
    }
}
