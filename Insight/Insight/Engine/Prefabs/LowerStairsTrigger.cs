using Insight.Engine.Components;
using Insight.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs
{
    class LowerStairsTrigger : Prefab
    {
        GameObject triggerModel;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            triggerModel = new GameObject(new Vector3(0, 0, 0), false);



            triggerModel.AddNewComponent<MeshRenderer>();
            triggerModel.GetComponent<MeshRenderer>().IsVisible = false;



            prefabGameObjects.Add(triggerModel);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            triggerModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.dispensertrigger, 1.0f);
            triggerModel.AddNewComponent<BoxCollider>();
            triggerModel.GetComponent<BoxCollider>().IsTrigger = true;
            triggerModel.Transform.Rotation = new Vector3(0);
            triggerModel.AddNewComponent<LowerStairsTriggerController>();
        }
    }
}
