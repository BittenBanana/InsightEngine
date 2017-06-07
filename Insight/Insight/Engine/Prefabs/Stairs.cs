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
    class Stairs : Prefab
    {
        GameObject stairsModel;
        GameObject stairsCollider;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            stairsModel = new GameObject(new Vector3(0, 0, 0), false);
            stairsModel.AddNewComponent<MeshRenderer>();
            
            stairsCollider = new GameObject(new Vector3(0, 0, 0), false);
            stairsCollider.AddNewComponent<MeshRenderer>();
            stairsCollider.GetComponent<MeshRenderer>().IsVisible = false;


            prefabGameObjects.Add(stairsModel);
            prefabGameObjects.Add(stairsCollider);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            stairsModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.stairs, 1.0f);

            //stairsModel.AddNewComponent<BoxCollider>();

            stairsCollider.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.stairsCollider, 1.0f);

            stairsCollider.AddNewComponent<BoxCollider>();
            stairsCollider.physicLayer = Layer.Stairs;

        }
    }
}
