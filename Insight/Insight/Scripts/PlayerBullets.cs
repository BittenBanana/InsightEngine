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
            Agressive,
            Transmitter
        }

        public bool aggresiveBullet { get; set; }
        public bool transmitterBullet { get; set; }
        public bool enemySightBullet { get; set; }
        public PlayerBullets(GameObject gameObject) : base(gameObject)
        {
            aggresiveBullet = false;
            transmitterBullet = true;
            enemySightBullet = false;
        }



    }
}
