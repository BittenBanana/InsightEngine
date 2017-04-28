using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{   
    class AudioManager
    {
        private List<Song> songs;
        private List<SoundEffect> soundEffects;
        private List<SoundEffectInstance> soundEffectInstances;
        private AudioListener audioListener;
        private List<AudioEmitter> audioEmitters;
        private GameObject playerListener;
        private ContentManager content;
        private List<GameObject> gameObjects;

        public AudioManager(GameObject playerListener, ContentManager content)
        {
            songs = new List<Song>();
            soundEffects = new List<SoundEffect>();
            soundEffectInstances = new List<SoundEffectInstance>();
            audioEmitters = new List<AudioEmitter>();
            audioListener = new AudioListener();
            gameObjects = new List<GameObject>();
            this.playerListener = playerListener;
            this.content = content;
        }

        public void LoadContent()
        {

        }

        public void Update()
        {
            audioListener.Position = playerListener.GetComponent<Camera>().Position;
            audioListener.Forward = playerListener.GetComponent<Camera>().view.Forward;
            audioListener.Up = playerListener.GetComponent<Camera>().view.Up;

            int j = 0;

            foreach(var audioEmitter in audioEmitters)
            {
                audioEmitter.Position = gameObjects[j].Transform.Position;
                j++;
            }

            int i = 0;

            foreach (var soundEffectInstance in soundEffectInstances)
            {
                soundEffectInstance.Apply3D(audioListener, audioEmitters[i]);
                i++;          
            }
        }

        public void AddSoundEffectWithEmitter(string soundEffectName, GameObject gameObject)
        {
            SoundEffect soundEffect = content.Load<SoundEffect>(soundEffectName);
            SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();
            soundEffectInstances.Add(soundEffectInstance);

            AudioEmitter audioEmitter = new AudioEmitter();
            audioEmitter.Position = gameObject.Transform.Position;
            audioEmitters.Add(audioEmitter);
            gameObjects.Add(gameObject);
        }

        public void PlaySoundEffect(int numberOfSoundEffect)
        {
            soundEffectInstances[numberOfSoundEffect].Play();
        }

        public void StopSoundEffect(int numberOfSoundEffect)
        {
            soundEffectInstances[numberOfSoundEffect].Stop();
        }

        public void SetSoundEffectLooped(int numberOfSoundEffect, bool isLooped)
        {
            soundEffectInstances[numberOfSoundEffect].IsLooped = isLooped;
        }

        public void SetSoundEffectsVolume(int numberOfSoundEffect, float value)
        {
            soundEffectInstances[numberOfSoundEffect].Volume = value;
        }

        public void AddSong(string songName)
        {
            Song song = content.Load<Song>(songName);
            songs.Add(song);
        }

        public void PlaySong(int numberOfSong)
        {
            MediaPlayer.Play(songs[numberOfSong]);            
        }

        public void StopCurrentSong()
        {
            MediaPlayer.Stop();
        }

        public void PauseCurrentSong()
        {
            MediaPlayer.Pause();
        }

        public void ResumeCurrentSong()
        {
            MediaPlayer.Resume();         
        }

        public void SetSongsVolume(float value)
        {
            MediaPlayer.Volume = value;
        }


    }
}
