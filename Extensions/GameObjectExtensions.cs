using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class GameObjectExtensions
    {
        // Author: Phillip Pierce (Adapted)
        /// <summary>
        /// Returns true if game object's layer is present in the given layer mask.
        /// </summary>
        /// <returns></returns>
        public static bool IsInLayerMask(this GameObject self, LayerMask mask) 
        {
            return ((mask.value & (1 << self.layer)) > 0);
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Get the first component of the type T found in the object.
        /// If it can't be found, a new one will be added to the object.
        /// </summary>
        /// <returns>Component added or found.</returns>
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            T updatedObject = self.GetComponent<T>();

            if (updatedObject)
                return updatedObject;

            return self.AddComponent<T>();
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Verifies if game object <paramref name="self"/> has component of type
        /// <typeparamref name="T"/>. If it doesn't, add it.
        /// </summary>
        /// <returns>Component added or found.</returns>
        public static T AddComponentOnlyIfItHasNot<T>(this GameObject self) where T : Component
        {
            T component = self.GetComponent<T>();

            if (component != null)
                return component;

            return self.AddComponent<T>();
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Returns true if the game object has a component of type T.
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool HasComponent<T>(this GameObject self) where T : Component
        {
            return !ReferenceEquals(self.GetComponent<T>(), null);
        }

        // Author: github.com/dracolytch/DracoSoftwareExtensionsForUnity
        /// <summary>
        /// Perform an action if a component exists, skip otherwise
        /// </summary>
        /// <typeparam name="T">The type of component required</typeparam>
        /// <param name="self"></param>
        /// <param name="callback">The action to take</param>
        /// <returns>The component found</returns>
        public static T GetComponent<T>(this GameObject self, System.Action<T> callback) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                callback.Invoke(component);
            }

            return component;
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Look for the component in this game object. If not found, 
        /// search through its children.
        /// </summary>
        /// <typeparam name="T">Unity component.</typeparam>
        /// <returns>The component, if found or null if not.</returns>
        public static T GetComponentInSelfOrChildren<T>(this GameObject self) where T : Component
        {
            var component = self.GetComponent<T>();

            if (!component)
                component = self.GetComponentInChildren<T>();

            return component;
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Look for the component in this game object. If not found, 
        /// search for it in its parent transform.
        /// </summary>
        /// <typeparam name="T">Unity component.</typeparam>
        /// <returns>The component, if found or null if not.</returns>
        public static T GetComponentInItselfOrParent<T>(this GameObject self) where T : Component
        {
            var component = self.GetComponent<T>();

            if (!component)
                component = self.GetComponentInParent<T>();

            return component;
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Looks for a component of given type in objects directly
        /// higher up in the hierarchy.
        /// </summary>
        /// <typeparam name="T">Unity engine component.</typeparam>
        /// <returns>Component of given type if found, null if otherwise.</returns>
        public static T GetComponentInAncestors<T>(this GameObject self) where T : Component
        {
            Transform currentAncestor = self.transform.parent;

            while (currentAncestor != null)
            {
                var targetComponent = currentAncestor.gameObject.GetComponent<T>();

                if (targetComponent != null)
                    return targetComponent;
                
                currentAncestor = currentAncestor.parent;
            }

            return null;
        }
    }
}
