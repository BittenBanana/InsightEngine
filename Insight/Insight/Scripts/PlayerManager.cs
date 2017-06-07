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
        private float timer;
        private float healTime;

        public int health { get; private set; }
        public PlayerManager(GameObject gameObject) : base(gameObject)
        {
            health = 100;
            healTime = 10;
        }

        public override void Update()
        {
            if (health < 100)
            {
                if (timer > healTime)
                {
                    health = 100;
                    timer = 0;
                }
                timer += Time.deltaTime;
            }

            if (health <= 0)
                SceneManager.Instance.currentScene.gameOver = true;
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
