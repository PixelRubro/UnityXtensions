using UnityEngine;

namespace YoukaiFox.UnityExtensions
{
    public static class ParticleExtensions 
    {
        // Author: Youkai Fox Studio
        /// <summary>
        /// Start playing even if it's already playing.
        /// </summary>
        public static void PlayForced(this ParticleSystem self)
        {
            if (!self)
                return;

            if (self.isPlaying)
                self.Stop();

            self.Play();
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Turn loop on and play.
        /// </summary>
        public static void PlayLooped(this ParticleSystem self)
        {
            if (!self)
                return;

            var main = self.main;
            main.loop = true;

            if (!self.isPlaying)
                self.Play();
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Set the particle system loop value with <param name="loop"> value.
        /// </summary>
        /// <param name="loop"></param>
        public static void Loop(this ParticleSystem self, bool loop)
        {
            if (!self)
                return;

            var main = self.main;
            main.loop = loop;
        }

        // Author: Youkai Fox Studio
        /// <summary>
        /// Set the particle system play on awake value with <param name="playOnAwake"> value.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="playOnAwake"></param>
        public static void PlayOnAwake(this ParticleSystem self, bool playOnAwake)
        {
            if (!self)
                return;

            var main = self.main;
            main.playOnAwake = playOnAwake;
        }

        // Author: Youkai Fox Studio
        public static void ChangeColor(this ParticleSystem self, Color color)
        {
            if (!self)
                return;

            var main = self.main;
            main.startColor = color;
        }
    }
}