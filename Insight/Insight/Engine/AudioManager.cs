using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Insight.Engine
{   
    public class AudioManager
    {
        private List<Song> songs;
        private List<Cue> cues;
        public AudioListener audioListener { get; private set; }
        private List<AudioEmitter> audioEmitters;
        private GameObject playerListener;
        private ContentManager content;
        private List<GameObject> gameObjects;

        public AudioEngine engine { get; private set; }
        public SoundBank soundBank { get; private set; }
        WaveBank waveBank;

        public AudioManager(GameObject playerListener, ContentManager content)
        {
            engine = new AudioEngine("Content/Audio/AudioEngine.xgs");
            waveBank = new WaveBank(engine, "Content/Audio/WaveBank.xwb");
            soundBank = new SoundBank(engine, "Content/Audio/SoundBank.xsb");

            songs = new List<Song>();
            cues = new List<Cue>();

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
            

            audioListener.Position = playerListener.Transform.Position;
            audioListener.Forward = playerListener.Transform.forward;
            audioListener.Up = Vector3.Up;

            int j = 0;

            foreach(var audioEmitter in audioEmitters)
            {
                audioEmitter.Position = gameObjects[j].Transform.Position;
                j++;
            }

            int i = 0;

            foreach (var cue in cues)
            {
                //float distance = cue.GetVariable("Distance");
                //    distance = Vector3.Distance(audioListener.Position, audioEmitters[i].Position);
                //cue.SetVariable("Distance", distance);
                cue.Apply3D(audioListener, audioEmitters[i]);
                
                i++;          
            }

            engine.Update();
        }

        public int AddCueWithEmitter(Cue cue, GameObject emitterGameObject)
        {
            AudioEmitter emitter = new AudioEmitter();
            emitter.Position = emitterGameObject.Transform.Position;

            cue.Apply3D(audioListener, emitter);           

            audioEmitters.Add(emitter);
            gameObjects.Add(emitterGameObject);
            cues.Add(cue);

            return cues.Count - 1;
            //cue.Play();
        }

        public void PlayCue(int number)
        {
            cues[number].Play();
        }

        //public SoundEffectInstance AddSoundEffectWithEmitter(string soundEffectName, GameObject gameObject)
        //{
        //    SoundEffect soundEffect = content.Load<SoundEffect>(soundEffectName);
        //    SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();
        //    soundEffectInstances.Add(soundEffectInstance);

        //    AudioEmitter audioEmitter = new AudioEmitter();
            
        //    audioEmitter.Position = gameObject.Transform.Position;
        //    audioEmitters.Add(audioEmitter);
        //    gameObjects.Add(gameObject);

        //    return soundEffectInstance;
        //}

        //[Obsolete("use PlaySoundEffect(SoundEffectInstance numberOfSoundEffect) instead")]
        //public void PlaySoundEffect(int numberOfSoundEffect)
        //{
        //    soundEffectInstances[numberOfSoundEffect].Play();
        //}
        //public void PlaySoundEffect(SoundEffectInstance numberOfSoundEffect)
        //{
        //    soundEffectInstances.Find(i => i.Equals(numberOfSoundEffect)).Play();
        //}

        //[Obsolete("use StopSoundEffect(SoundEffectInstance numberOfSoundEffect) instead")]
        //public void StopSoundEffect(int numberOfSoundEffect)
        //{
        //    soundEffectInstances[numberOfSoundEffect].Stop();
        //}
        //public void StopSoundEffect(SoundEffectInstance numberOfSoundEffect)
        //{
        //    soundEffectInstances.Find(i => i.Equals(numberOfSoundEffect)).Stop();
        //}

        //public void SetSoundEffectLooped(int numberOfSoundEffect, bool isLooped)
        //{
        //    soundEffectInstances[numberOfSoundEffect].IsLooped = isLooped;
        //}

        //public void SetSoundEffectsVolume(int numberOfSoundEffect, float value)
        //{
        //    soundEffectInstances[numberOfSoundEffect].Volume = value;
        //}

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
