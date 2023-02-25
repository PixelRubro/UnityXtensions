using UnityEngine;

namespace PixelSpark.UnityXtensions
{
    public static class SpriteRendererExtensions
    {
        public static void SetColorR(this SpriteRenderer self, float value)
        {
            self.color = new Color(value, self.color.g, self.color.b, self.color.a);
        }

        public static void SetColorG(this SpriteRenderer self, float value)
        {
            self.color = new Color(self.color.r, value, self.color.b, self.color.a);
        }

        public static void SetColorB(this SpriteRenderer self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, value, self.color.a);
        }

        public static void SetColorA(this SpriteRenderer self, float value)
        {
            self.color = new Color(self.color.r, self.color.g, self.color.b, value);
        }
    }
}
