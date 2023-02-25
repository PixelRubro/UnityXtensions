using System.Collections.Generic;

namespace PixelSparkStudio.UnityXtensions
{
    public static class ICollectionExtensions 
    {
        /// <summary>
        /// Adds each one of the items in <paramref name="items"/>.
        /// </summary>
        public static void Add<T>(this ICollection<T> self, params T[] items)
        {
            foreach (var item in items)
            {
                self.Add(item);
            }
        }

        /// <summary>
        /// Removes each one of the items in <paramref name="items"/>
        /// if they are found.
        /// </summary>
        /// <returns>True if all provided items were removed.</returns>
        public static bool Remove<T>(this ICollection<T> self, params T[] items)
        {
            var removedAll = true;

            foreach (var item in items)
            {
                var removed = self.Remove(item);

                if (!removed)
                    removedAll = false;
            }

            return removedAll;
        } 
    }
}