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
    class Crate : Prefab
    {
        public GameObject crateModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            crateModel = new GameObject(new Vector3(0, 0, 0), false);
            crateModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(crateModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            crateModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.crate, 1.0f);
            crateModel.AddNewComponent<BoxCollider>();
            crateModel.physicLayer = Layer.IgnoreRaycast;

        }
    }
}
