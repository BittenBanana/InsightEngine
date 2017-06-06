using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scripts
{
    abstract class EnemyAIState
    {
        public abstract void EnterState(EnemyAI enemy);
        public abstract void Execute(EnemyAI enemy);
        public abstract void Exit(EnemyAI enemy);
    }
}
