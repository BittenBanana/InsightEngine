using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Insight.Scripts.EnemyStates
{
    class FollowMarkerState : EnemyAIState
    {
        private float timer;
        private float wait;

        private float soundTimer, soundDelay, moveSpeed;

        private int footCueNumber;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 10;

            soundTimer = 0;
            moveSpeed = 0.05f;
            soundDelay = (1 / moveSpeed) / 50;

            footCueNumber = SceneManager.Instance.currentScene.audioManager.AddCueWithEmitter(
                SceneManager.Instance.currentScene.audioManager.soundBank.GetCue("Foots"), enemy.gameObject);

            Debug.WriteLine("Enter Marker State");
            enemy.detect = false;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (enemy.markerPosition != null)
            {
                if (EnemyWalkingSpots.getInstance()
                        .DistanceFromDestination(enemy.gameObject.Transform.Position, (Vector3) enemy.markerPosition) >
                    0.1f)
                {
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                    EnemyWalkingSpots.getInstance()
                        .MoveGameObjectToDestination(enemy.gameObject, (Vector3) enemy.markerPosition, 0.05f, 0.1f);
                    if (soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(footCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }
                else
                {
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 8)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(8,true);
                    if (timer >= wait)
                    {
                        enemy.ChangeState(enemy.defaultState);
                    }
                    timer += Time.deltaTime;
                }
            }
            else
            {
                enemy.ChangeState(enemy.defaultState);
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            enemy.detect = true;
            Debug.WriteLine("Exit Marker State");
        }
    }
}
