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
    class BigMachine : Prefab
    {
        GameObject machineModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            machineModel = new GameObject(new Vector3(0, 0, 0), false);
            machineModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(machineModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            machineModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.bigMachine, 1.0f);
            machineModel.AddNewComponent<BoxCollider>();

        }
    }
}
