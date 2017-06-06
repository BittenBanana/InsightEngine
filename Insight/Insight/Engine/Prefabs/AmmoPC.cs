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
    class AmmoPC : Prefab
    {
        public GameObject pcModel;
        GameObject triggerModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            pcModel = new GameObject(new Vector3(0, 0, 0), false);
            triggerModel = new GameObject(new Vector3(0, 0, 0), false);



            pcModel.AddNewComponent<MeshRenderer>();
            triggerModel.AddNewComponent<MeshRenderer>();
            triggerModel.GetComponent<MeshRenderer>().IsVisible = false;



            prefabGameObjects.Add(pcModel);
            prefabGameObjects.Add(triggerModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            pcModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.ammo_pc, 1.0f);
            triggerModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.dispensertrigger, 1.0f);
            pcModel.AddNewComponent<BoxCollider>();
            triggerModel.AddNewComponent<BoxCollider>();
            triggerModel.GetComponent<BoxCollider>().IsTrigger = true;
            triggerModel.Transform.Rotation = new Vector3(0);
            triggerModel.AddNewComponent<DispenserTriggerController>();
        }
    }
}
