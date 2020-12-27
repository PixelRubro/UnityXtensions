namespace YoukaiFox.UnityExtensions.GameObject
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns true if game object's layer is present in the given layer mask.
        /// </summary>
        /// <returns></returns>
        public static bool IsInLayerMask(this UnityEngine.GameObject currentObject, UnityEngine.LayerMask mask) 
        {
            return ((mask.value & (1 << currentObject.layer)) > 0);
        }

        /// <summary>
        /// Get the first component of the type T found in the object.
        /// If it can't be found, a new one will be added to the object.
        /// </summary>
        /// <param name="currentObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this UnityEngine.GameObject currentObject) 
            where T : UnityEngine.Component
        {
            T updatedObject = currentObject.GetComponent<T>();

            if (updatedObject)
                return updatedObject;

            return currentObject.AddComponent<T>();
        }

        /// <summary>
        /// Returns true if the game object has a component of type T.
        /// </summary>
        /// <param name="currentObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool HasComponent<T>(this UnityEngine.GameObject currentObject)
            where T : UnityEngine.Component
        {
            return !ReferenceEquals(currentObject.GetComponent<T>(), null);
        }
    }
}
