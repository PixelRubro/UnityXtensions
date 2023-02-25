using UnityEngine;
using UnityEngine.UI;

namespace PixelSpark.UnityXtensions
{
    public static class GraphicExtensions
    {
        public static void SetColorR(this Graphic self, float value)
        {
            self.color = new Color(value, self.color.g, self.color.b, self.color.a);
        }

        public static void SetColorG(this Graphic self, float value)
        {
            self.color = new Color(self.color.r, value, self.color.b, self.color.a);
        }

        public static void SetColorB(this Graphic self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, value, self.color.a);
        }

        public static void SetColorA(this Graphic self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, self.color.b, value);
        }
    }
}
