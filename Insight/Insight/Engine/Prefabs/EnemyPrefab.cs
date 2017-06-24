using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;
using Insight.Materials;
using Insight.Scripts;
using Insight.Scripts.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Insight.Engine.Prefabs
{
    class EnemyPrefab : Prefab
    {
        public GameObject enemy;
        public GameObject enemySightTrigger;
        public List<Vector3> patrolPos { get; set; }
        public EnemyPrefab(List<Vector3> positions)
        {
            patrolPos = positions;
        }

        public override void Initialize(Vector3 position)
        {
            enemy = new GameObject(new Vector3(0, 0, 0), false);
            enemy.AddNewComponent<AnimationRender>();

            enemySightTrigger = new GameObject(enemy.Transform.Position, false);
            enemySightTrigger.AddNewComponent<MeshRenderer>();
            enemySightTrigger.GetComponent<MeshRenderer>().IsVisible = false;

            prefabGameObjects.Add(enemy);
            
            prefabGameObjects.Add(enemySightTrigger);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            enemy.LoadContent(content);
            enemy.GetComponent<AnimationRender>().Load(content, AnimationRender.AnimationModel.Player);
            enemy.GetComponent<Renderer>().LoadTexture(content, "Materials/corridor-straight_DefaultMaterial_AlbedoTransparency");
            enemy.GetComponent<Renderer>().LoadNormalMap(content, "Materials/corridor-straight_DefaultMaterial_Normal");
            enemy.GetComponent<Renderer>().LoadAmbientOcclusionMap(content, "Materials/corridor-straight_DefaultMaterial_AO");
            enemy.GetComponent<Renderer>().LoadMetalnessMap(content, "Materials/corridor-straight_DefaultMaterial_MetallicSmoothness");
            enemy.AddNewComponent<EnemyAI>();
            enemy.AddNewComponent<SphereCollider>();
            enemy.physicLayer = Layer.Enemy;

            enemySightTrigger.LoadContent(content, ContentModels.Instance.ball, 2.5f);
            enemySightTrigger.AddNewComponent<SphereCollider>();
            enemySightTrigger.GetComponent<SphereCollider>().IsTrigger = true;
            enemySightTrigger.AddNewComponent<EnemySight>();
            enemySightTrigger.GetComponent<EnemySight>().enemy = enemy;
            enemySightTrigger.physicLayer = Layer.DispenserTrigger;

            enemy.GetComponent<EnemyAI>().enemySight = enemySightTrigger.GetComponent<EnemySight>();
            //enemy.GetComponent<EnemyAI>().patrolPositions.Add(new Vector3(18.5f, 0, 6f));
            //enemy.GetComponent<EnemyAI>().patrolPositions.Add(new Vector3(18.5f, 0, 13.5f));
            enemy.GetComponent<EnemyAI>().SetPatrolPositions(patrolPos);
            enemy.GetComponent<EnemyAI>().SetFirstState(new PatrolState());
            SceneManager.Instance.currentScene.enemies.Add(enemySightTrigger);
            base.LoadContent(content);
        }
    }
}
