using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs
{
    class Prefab
    {

        protected List<GameObject> prefabGameObjects = new List<GameObject>();
        public virtual void Initialize(Vector3 position)
        {
            foreach (GameObject go in prefabGameObjects)
            {
                go.Transform.Position += position;
                SceneManager.Instance.currentScene.GetGameObjectsFromScene().Add(go);
            }
        }

        public virtual void LoadContent(ContentManager content)
        {

        }
        
    }
}
