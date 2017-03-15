using Insight.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts
{
    public abstract class BaseScript : Component
    {
        public BaseScript(GameObject gameObject) : base (gameObject)
        {
        }
    }
}
