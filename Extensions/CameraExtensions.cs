using UnityEngine;

namespace YoukaiFox.UnityExtensions.Camera
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Get the bounds of an ortographic camera.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static Bounds OrthographicBounds(this UnityEngine.Camera camera)
        {
            float screenAspect = (float) Screen.width / (float) Screen.height;
            float cameraHeight = camera.orthographicSize * 2;
            Vector3 boundsCenter = camera.transform.position;
            Vector3 boundsSize = new Vector3(cameraHeight * screenAspect, cameraHeight, 0f);
            return new Bounds(boundsCenter, boundsSize);
        }

        /// <summary>
        /// Calculates and returns the world position of point in a plane on the Z axis.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="screenPosition"></param>
        /// <param name="zPlane"></param>
        /// <returns></returns>
        public static Vector3 GetWorldPositionOnPlane(this UnityEngine.Camera camera, Vector3 screenPosition, float zPlane) 
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            Plane plane = new Plane(Vector3.forward, new Vector3(0f, 0f, zPlane));
            plane.Raycast(ray, out float distance);
            return ray.GetPoint(distance);
        }
    }
}
