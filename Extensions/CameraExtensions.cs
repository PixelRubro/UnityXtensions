using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Get the bounds of an ortographic camera.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static Bounds OrthographicBounds(this Camera camera)
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
        public static Vector3 GetWorldPositionOnPlane(this Camera camera, Vector3 screenPosition, float zPlane) 
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            Plane plane = new Plane(Vector3.forward, new Vector3(0f, 0f, zPlane));
            plane.Raycast(ray, out float distance);
            return ray.GetPoint(distance);
        }

        public static float ScreenToWorldSize(this Camera camera, float pixelSize, float clipPlane)
        {
            if (camera.orthographic)
            {
                return pixelSize * camera.orthographicSize * 2f / camera.pixelHeight;
            }

            return pixelSize * clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2f /
                   camera.pixelHeight;
        }

        public static float WorldToScreenSize(this Camera camera, float worldSize, float clipPlane)
        {
            if (camera.orthographic)
            {
                return worldSize * camera.pixelHeight * 0.5f / camera.orthographicSize;
            }

            return worldSize * camera.pixelHeight * 0.5f /
                   (clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
        }
    }
}
