using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts
{
    class PlayerManager :BaseScript
    {
        private float timer, restoreTimer;
        private float healTime, restoreDelay;

        public float detectionLevel { get; set; }

        public int health { get; private set; }
        public PlayerManager(GameObject gameObject) : base(gameObject)
        {
            health = 100;
            healTime = 10;
            restoreTimer = 0;
            timer = 0;
            restoreDelay = 0.025f;
        }

        public override void Update()
        {
            if (health < 100)
            {
                if (timer > healTime)
                {
                    if (restoreTimer > restoreDelay)
                    {
                        health += 1;
                        restoreTimer = 0;
                    }
                    restoreTimer += Time.deltaTime;
                }
                timer += Time.deltaTime;
            }
            if (health == 100)
            {
                timer = 0;
            }

            if (health <= 0)
                SceneManager.Instance.currentScene.gameOver = true;
            float detLvl = 0;
            foreach (GameObject enemy in SceneManager.Instance.currentScene.enemies)
            {
                detLvl = Math.Max(detLvl, enemy.GetComponent<EnemySight>().detectionLevel);
            }
            detectionLevel = detLvl;
            base.Update();
        }

        public void GotDamage(int dmg)
        {
            timer = 0;
            if(health > 0)
                health -= dmg;
        }
    }
}
