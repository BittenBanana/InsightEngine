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
    class DoorSmaller : Prefab
    {
        GameObject doorModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            doorModel = new GameObject(new Vector3(0, 0, 0), false);

            doorModel.AddNewComponent<MeshRenderer>();



            prefabGameObjects.Add(doorModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            doorModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.wall_5x4_dm_g, 1.0f);

            doorModel.AddNewComponent<BoxCollider>();

        }
    }
}
