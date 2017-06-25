using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework.Audio;

namespace Insight.Scripts.EnemyStates
{
    class CheckState : EnemyAIState
    {
        private float timer;
        private float wait;

        private Random rand;
        List<SoundEffectInstance> sounds = new List<SoundEffectInstance>();
        private float soundTimer, soundDelay, moveSpeed;
        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 10;

            soundTimer = 0;
            moveSpeed = 0.05f;
            soundDelay = (1 / moveSpeed) / 50;

            rand = new Random();
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/enemyfoot1", enemy.gameObject));
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/enemyfoot2", enemy.gameObject));
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/enemyfoot3", enemy.gameObject));
            sounds.Add(SceneManager.Instance.currentScene.audioManager.AddSoundEffectWithEmitter("Audio/enemyfoot4", enemy.gameObject));

            Debug.WriteLine("Enter Check State");
        }

        public override void Execute(EnemyAI enemy)
        {
            if (EnemyWalkingSpots.getInstance()
                    .DistanceFromDestination(enemy.gameObject.Transform.Position, enemy.enemySight.lastHeardPosition) >
                0.1f)
            {
                if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                    enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                EnemyWalkingSpots.getInstance()
                    .MoveGameObjectToDestination(enemy.gameObject, enemy.enemySight.lastHeardPosition, 0.05f, 0.1f);
                if (soundTimer > soundDelay)
                {
                    SceneManager.Instance.currentScene.audioManager.PlaySoundEffect(sounds[rand.Next(0, sounds.Count - 1)]);
                    soundTimer = 0;
                }
                soundTimer += Time.deltaTime;
            }
            else
            {
                if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 0)
                    enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(0,true);
                if (timer >= wait)
                {
                    if (enemy.enemySight.detectionLevel <= 0.75f)
                    {
                        enemy.ChangeState(enemy.defaultState);
                    }
                    timer = 0;
                }
                timer += Time.deltaTime;
            }
            if (enemy.enemySight.detectionLevel > 0.9f)
            {
                enemy.ChangeState(new ChaseState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Check State");
        }
    }
}
