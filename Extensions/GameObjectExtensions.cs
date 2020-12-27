using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns true if game object's layer is present in the given layer mask.
        /// </summary>
        /// <returns></returns>
        public static bool IsInLayerMask(this GameObject self, LayerMask mask) 
        {
            return ((mask.value & (1 << self.layer)) > 0);
        }

        /// <summary>
        /// Get the first component of the type T found in the object.
        /// If it can't be found, a new one will be added to the object.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this GameObject self) 
            where T : Component
        {
            T updatedObject = self.GetComponent<T>();

            if (updatedObject)
                return updatedObject;

            return self.AddComponent<T>();
        }

        /// <summary>
        /// Returns true if the game object has a component of type T.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool HasComponent<T>(this GameObject self)
            where T : Component
        {
            return !ReferenceEquals(self.GetComponent<T>(), null);
        }
    }
}
