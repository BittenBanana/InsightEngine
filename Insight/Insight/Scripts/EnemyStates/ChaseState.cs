﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework.Audio;

namespace Insight.Scripts.EnemyStates
{
    class ChaseState : EnemyAIState
    {
        private float timer;
        private float wait;

        private float shootTimer;
        private float shootWait;
        private float shootDistance;

        private float soundTimer, soundDelay, moveSpeed;

        private int footCueNumber;

        public override void EnterState(EnemyAI enemy)
        {
            timer = 0;
            wait = 15;

            soundTimer = 0;
            moveSpeed = 0.05f;
            soundDelay = (1 / moveSpeed) / 50;

            footCueNumber = SceneManager.Instance.currentScene.audioManager.AddCueWithEmitter(
                SceneManager.Instance.currentScene.audioManager.soundBank.GetCue("Foots"), enemy.gameObject);

            shootTimer = 0;
            shootWait = 0.75f;
            shootDistance = 5;
            Debug.WriteLine("Enter Chase State");
        }

        public override void Execute(EnemyAI enemy)
        {
            if (enemy.enemySight.detectionLevel <= 0.9f)
            {
                if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                        enemy.enemySight.lastHeardPosition) < 0.1f)
                {
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 0)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(0,true);
                    if (timer >= wait)
                    {
                        if (enemy.enemySight.detectionLevel > 0.6f)
                            enemy.ChangeState(new CheckState());
                        else
                        {
                            enemy.ChangeState(enemy.defaultState);
                        }
                        timer = 0;
                    }
                    timer += Time.deltaTime;
                }
                else
                {
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                    EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject,
                        enemy.enemySight.lastHeardPosition, moveSpeed, 0.1f);
                    if (soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(footCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }

            }
            else if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position, enemy.enemySight.lastHeardPosition) > 0.1f)
            {
                if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                        enemy.enemySight.player.Transform.Position) > shootDistance)
                {
                    EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject,
                        enemy.enemySight.lastHeardPosition, moveSpeed, 0.1f);
                    if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                        enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                    if (soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(footCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }

            }

            if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                    enemy.enemySight.player.Transform.Position) <= shootDistance)
            {
                if (shootTimer >= shootWait)
                {
                    enemy.ChangeState(new ShootState());
                    shootTimer = 0;
                }
                shootTimer += Time.deltaTime;
            }

        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Chase State");
        }
    }
}
