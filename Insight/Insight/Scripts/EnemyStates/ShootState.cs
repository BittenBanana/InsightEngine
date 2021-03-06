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
    class ShootState : EnemyAIState
    {
        private Physics.RaycastHit hit;
        private Random random;
        private int minRand;
        private int maxRand;
        private Random rand;
        private int shootCueNumber;

        public override void EnterState(EnemyAI enemy)
        {
            Debug.WriteLine("Enter Shoot State");
            rand = new Random();
            minRand = 1;
            maxRand = 20;
            random = new Random();
            if (enemy.gameObject.GetComponent<AnimationRender>().animationId != 7)
                enemy.gameObject.GetComponent<AnimationRender>().ChangeAnimation(7,true); // TODO Shoot Animation
            shootCueNumber = SceneManager.Instance.currentScene.audioManager.AddCueWithEmitter(
                SceneManager.Instance.currentScene.audioManager.soundBank.GetCue("Shoots"), enemy.gameObject);
            SceneManager.Instance.currentScene.audioManager.PlayCue(shootCueNumber);
        }

        public override void Execute(EnemyAI enemy)
        {
            Vector3 direction = enemy.enemySight.player.Transform.Position - enemy.gameObject.Transform.Position;
            direction += new Vector3((float)random.Next(minRand,maxRand) / 100, (float)random.Next(minRand, maxRand) / 100, (float)random.Next(minRand, maxRand) / 100);
            direction.Normalize();
            if (Physics.Raycast(enemy.gameObject.Transform.Position + direction / 2, direction, out hit))
            {
                if (hit.collider.gameObject.physicLayer == Layer.Player)
                {
                    hit.collider.gameObject.GetComponent<PlayerManager>().GotDamage(random.Next(20, 45));
                }
            }
            enemy.ChangeState(enemy.previousState);
        }

        public override void Exit(EnemyAI enemy)
        {
            Debug.WriteLine("Exit Shoot State");
        }
    }
}
