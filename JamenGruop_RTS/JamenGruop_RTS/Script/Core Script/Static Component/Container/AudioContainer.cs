using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public static class AudioContainer
	{
		private static Dictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>();
		private static Dictionary<string, Song> songs = new Dictionary<string, Song>();

		public static Dictionary<string, SoundEffect> SoundEffects { get => soundEffects; private set => soundEffects = value; }
		public static Dictionary<string, Song> Songs { get => songs; private set => songs = value; }

		public static void LoadContent(ContentManager content)
		{
			// Songs
			//AddSongs(content.Load<Song>("Audio/Adventure/Song/rpgSong"), "AdventureSong");

			// Sound Effects
			//AddSoundEffects(content.Load<SoundEffect>("Audio/Adventure/Sound/GunOutOfAmmoSound"), "GunOutOfAmmoSound");
		}

		private static void AddSongs(Song song, string name)
		{
			Songs.Add(name, song);
		}
		private static void AddSoundEffects(SoundEffect soundEffect, string name)
		{
			SoundEffects.Add(name, soundEffect);
		}
	}
}
