﻿using System;
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
    class AgressiveState : EnemyAIState
    {
        private float minDistance = float.PositiveInfinity;
        private float soundTimer, soundDelay, moveSpeed;
        private int footCueNumber;

        public override void EnterState(EnemyAI enemy)
        {
            soundTimer = 0;
            moveSpeed = 0.1f;
            soundDelay = (1 / moveSpeed) / 50;

            footCueNumber = SceneManager.Instance.currentScene.audioManager.AddCueWithEmitter(
                SceneManager.Instance.currentScene.audioManager.soundBank.GetCue("Foots"), enemy.gameObject);

            enemy.HeathBoost(50);
            if (enemy.enemySight.detectionLevel >= 0.5f)
            {
                enemy.nearestEnemyPosition = enemy.enemySight.player;
                return;
            }
            Debug.WriteLine("Enter Agressive State");
            foreach (GameObject item in SceneManager.Instance.GetGameObjectsFromCurrentScene())
            {
                if(item.physicLayer != Layer.Enemy && item.physicLayer != Layer.Player) continue;
                if(item == enemy.gameObject) continue;
                if(item.physicLayer == Layer.Enemy && (item.GetComponent<EnemyAI>()?.currentState is DeathState || item.GetComponent<EnemyAI>()?.currentState is ParalysisState)) continue;
                if (enemy.nearestEnemyPosition == null)
                {
                    enemy.nearestEnemyPosition = item;
                    minDistance = Vector3.Distance(item.Transform.Position, enemy.gameObject.Transform.Position);
                }
                else
                {
                    float distance = Vector3.Distance(item.Transform.Position, enemy.gameObject.Transform.Position);
                    if (distance < minDistance)
                    {
                        enemy.nearestEnemyPosition = item;
                        minDistance = distance;
                    }
                }
            }
            
            enemy.detect = false;
        }

        public override void Execute(EnemyAI enemy)
        {
            if (EnemyWalkingSpots.getInstance().DistanceFromDestination(enemy.gameObject.Transform.Position,
                    enemy.nearestEnemyPosition.Transform.Position) > 0.1f)
            {
                if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 1)
                    enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(1,true);
                EnemyWalkingSpots.getInstance().MoveGameObjectToDestination(enemy.gameObject,
                    enemy.nearestEnemyPosition.Transform.Position, moveSpeed, 0.1f);
                if (soundTimer > soundDelay)
                {
                    SceneManager.Instance.currentScene.audioManager.PlayCue(footCueNumber);
                    soundTimer = 0;
                }
                soundTimer += Time.deltaTime;
            }
            else if(Vector3.Distance(enemy.gameObject.Transform.Position, enemy.nearestEnemyPosition.Transform.Position) < 1)
            {
                if (enemy.nearestEnemyPosition.physicLayer == Layer.Enemy)
                {
                    //enemy.nearestEnemyPosition.GetComponent<EnemyAI>().nearestEnemyPosition = enemy.gameObject;
                    enemy.nearestEnemyPosition.GetComponent<EnemyAI>().ChangeState(new FightState());
                }
                enemy.ChangeState(new FightState());
            }
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Agressive State");
        }
    }
}
