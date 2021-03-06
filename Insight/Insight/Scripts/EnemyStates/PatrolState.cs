﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using Insight.Engine.Components;
using Microsoft.Xna.Framework.Audio;

namespace Insight.Scripts.EnemyStates
{
    class PatrolState : EnemyAIState
    {
        private Vector3 currentDestination;
        private int destIterator, footCueNumber;

        private float timer;
        private float wait;

        private float soundTimer, soundDelay, moveSpeed;

        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Patrol State");
            destIterator = 0;
            currentDestination = enemy.patrolPositions[destIterator];
            timer = 0;
            wait = 5;

            soundTimer = 0;
            moveSpeed = 0.05f;
            soundDelay = (1 / moveSpeed) / 50;

            footCueNumber = SceneManager.Instance.currentScene.audioManager.AddCueWithEmitter(
                SceneManager.Instance.currentScene.audioManager.soundBank.GetCue("Foots"), enemy.gameObject);
        }

        public override void Execute(EnemyAI enemy)
        {
            if (EnemyWalkingSpots.getInstance()
                    .DistanceFromDestination(enemy.gameObject.Transform.Position, currentDestination) > 0.1f)
            {
                if(enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                     enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                EnemyWalkingSpots.getInstance()
                    .MoveGameObjectToDestination(enemy.gameObject, currentDestination, 0.05f, 0.1f);
                if (soundTimer > soundDelay)
                {
                    SceneManager.Instance.currentScene.audioManager.PlayCue(footCueNumber);
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
                    if (destIterator < enemy.patrolPositions.Count - 1)
                    {
                        destIterator++;
                    }
                    else
                    {
                        destIterator = 0;
                    }
                    currentDestination = enemy.patrolPositions[destIterator];
                    timer = 0;
                }
                timer += Time.deltaTime;
            }

            if (enemy.enemySight.detectionLevel > 0.9f)
            {
                enemy.ChangeState(new ChaseState());
            }
            else if (enemy.enemySight.detectionLevel > 0.6f && enemy.enemySight.detectionLevel <= 0.9f)
            {
                enemy.ChangeState(new CheckState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Patrol State");
        }
    }
}
