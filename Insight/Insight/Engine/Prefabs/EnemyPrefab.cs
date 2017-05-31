using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;
using Insight.Materials;
using Insight.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Insight.Engine.Prefabs
{
    class EnemyPrefab : Prefab
    {
        private GameObject enemy;
        private GameObject enemySightTrigger;

        public override void Initialize(Vector3 position)
        {
            enemy = new GameObject(position, true);
            enemy.AddNewComponent<MeshRenderer>();

            

            enemySightTrigger = new GameObject(new Vector3(17,0,0), false);
            enemySightTrigger.AddNewComponent<MeshRenderer>();
            enemySightTrigger.GetComponent<MeshRenderer>().IsVisible = false;
            
            prefabGameObjects.Add(enemy);
            prefabGameObjects.Add(enemySightTrigger);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            enemy.LoadContent(content);
            enemy.GetComponent<Renderer>().LoadTexture(content, "Materials/corridor-straight_DefaultMaterial_AlbedoTransparency");
            enemy.GetComponent<Renderer>().LoadNormalMap(content, "Materials/corridor-straight_DefaultMaterial_Normal");
            enemy.GetComponent<Renderer>().LoadAmbientOcclusionMap(content, "Materials/corridor-straight_DefaultMaterial_AO");
            enemy.GetComponent<Renderer>().LoadMetalnessMap(content, "Materials/corridor-straight_DefaultMaterial_MetallicSmoothness");
            enemy.AddNewComponent<BasicAI>();
            enemy.AddNewComponent<SphereCollider>();

            enemySightTrigger.LoadContent(content, "Models/ball", 1f);
            enemySightTrigger.AddNewComponent<SphereCollider>();
            enemySightTrigger.GetComponent<SphereCollider>().IsTrigger = true;
            enemySightTrigger.AddNewComponent<EnemySight>();
            enemySightTrigger.GetComponent<EnemySight>().followTransform = enemy.Transform;
            base.LoadContent(content);
        }
    }
}
