using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    public static class AudioPlayer
    {
        /// <summary>
        /// Play a song
        /// </summary>
        /// <param name="name">Name of song</param>
        /// <param name="volume">Volume of song</param>
        /// <param name="repeating">Repeating of song</param>
        public static void PlaySong(string name, float volume, bool repeating)
        {
            if (AudioContainer.Songs.ContainsKey(name))
            {
                MediaPlayer.Stop();

                Song tmp = AudioContainer.Songs[name];

                MediaPlayer.Play(tmp);
                MediaPlayer.Volume = volume;
                MediaPlayer.IsRepeating = repeating;
            }
            else
            {
                Console.WriteLine("Cant play song '" + name + "' as it was not fount");
            }
        }

        /// <summary>
        /// Stop a song
        /// </summary>
        public static void StopSong()
        {
            MediaPlayer.Stop();
        }

        /// <summary>
        /// Set Volume On Song
        /// </summary>
        /// <param name="volume">0 to 1 volume</param>
        public static void SetVolumeOnSong(float volume)
        {
            MediaPlayer.Volume = volume;
        }

        /// <summary>
        /// Play a soundEffect
        /// </summary>
        /// <param name="name">Name of soundEffect</param>
        /// <param name="volume">Volume of soundEffect</param>
        public static void PlaySoundEffect(string name, float volume)
        {
            _PlaySoundEffect(name, volume, 0, 0);
        }

        /// <summary>
        /// Play a soundEffect
        /// </summary>
        /// <param name="name">Name of soundEffect</param>
        /// <param name="volume">Volume of soundEffect</param>
        /// <param name="pitch">Pitch of soundEffect</param>
        /// <param name="pan">Pan of soundEffect</param>
        public static void PlaySoundEffect(string name, float volume, float pitch, float pan)
        {
            _PlaySoundEffect(name, volume, pitch, pan);
        }
        
        /// <summary>
        /// a private of PlaySoundEffect so we only have to edit it in one place
        /// </summary>
        /// <param name="name">Name of soundEffect</param>
        /// <param name="volume">Volume of soundEffect</param>
        /// <param name="pitch">Pitch of soundEffect</param>
        /// <param name="pan">Pan of soundEffect</param>
        private static void _PlaySoundEffect(string name, float volume, float pitch, float pan)
        {
            if (AudioContainer.SoundEffects.ContainsKey(name))
            {
                SoundEffect tmp = AudioContainer.SoundEffects[name];
                tmp.Play(volume: volume, pitch: pitch, pan: pan);
            }
            else
            {
                Console.WriteLine("Cant play sound effect '" + name + "' as it was not fount");
            }
        }
    }
}
