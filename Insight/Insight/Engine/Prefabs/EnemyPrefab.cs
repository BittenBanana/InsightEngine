using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;
using Insight.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Insight.Engine.Prefabs
{
    class EnemyPrefab : Prefab
    {
        private GameObject enemy;
        private GameObject enemySightCollider;

        public override void Initialize(Vector3 position)
        {
            enemy = new GameObject(position, false);
            enemy.AddNewComponent<AnimationRender>();

            enemySightCollider = new GameObject(new Vector3(17,0,0), false);
            enemySightCollider.AddNewComponent<MeshRenderer>();
            
            prefabGameObjects.Add(enemy);
            prefabGameObjects.Add(enemySightCollider);
        }

        public override void LoadContent(ContentManager content)
        {
            enemy.LoadContent(content, "Models/Konrads/Character/superBoxHero", 0.5f);
            enemy.AddNewComponent<BasicAI>();
            enemy.AddNewComponent<SphereCollider>();

            enemySightCollider.LoadContent(content, "Models/ball", 10f);
            enemySightCollider.AddNewComponent<SphereCollider>();
            enemySightCollider.GetComponent<SphereCollider>().IsTrigger = true;
            enemySightCollider.AddNewComponent<EnemySight>();
            enemySightCollider.GetComponent<EnemySight>().followTransform = enemy.Transform;
        }
    }
}
