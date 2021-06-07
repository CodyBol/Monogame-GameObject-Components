using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace Engine.Component
{
    public class SoundEffectController : BaseComponent
    {
        private Dictionary<string, SoundEffect> _soundEffects;
        
        public SoundEffectController(Dictionary<string, SoundEffect> soundEffects)
        {
            _soundEffects = soundEffects;
        }

        public void PlaySound(string soundName)
        {
            _soundEffects[soundName].Play();
        }
    }
}