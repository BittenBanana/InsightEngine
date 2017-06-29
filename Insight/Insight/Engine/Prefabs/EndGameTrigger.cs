using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Insight.Scripts;

namespace Insight.Engine.Prefabs
{
    class EndGameTrigger : Prefab
    {
        GameObject trigger;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();
            
            trigger = new GameObject(new Vector3(0, 0, 0), false);
            
            trigger.AddNewComponent<MeshRenderer>();
            trigger.GetComponent<MeshRenderer>().IsVisible = false;
            
            prefabGameObjects.Add(trigger);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {
            //base.LoadContent(content);
            trigger.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.dispensertrigger, 1.0f);

            trigger.AddNewComponent<BoxCollider>();
            trigger.GetComponent<BoxCollider>().IsTrigger = true;
            trigger.Transform.Rotation = new Vector3(0);
            trigger.AddNewComponent<EndGameController>();
        }
    }
}
