using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;

namespace Insight.Scripts
{
    class PlayerBullets : BaseScript
    {
        public enum Bullets
        {
            Paralysis,
            Transmitter,
            Agressive
        }

        public bool aggresiveBullet { get; set; }
        public bool transmitterBullet { get; set; }
        public bool paralysisBullet { get; set; }
        public PlayerBullets(GameObject gameObject) : base(gameObject)
        {
            aggresiveBullet = true;
            transmitterBullet = true;
            paralysisBullet = true;
        }



    }
}
