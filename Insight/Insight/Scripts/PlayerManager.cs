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
        public int health { get; private set; }
        public PlayerManager(GameObject gameObject) : base(gameObject)
        {
            health = 100;
        }

        public void GotDamage(int dmg)
        {
            health -= dmg;
        }
    }
}
