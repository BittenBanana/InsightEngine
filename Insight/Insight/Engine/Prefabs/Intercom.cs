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
    class Intercom : Prefab
    {
        GameObject intercomModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            intercomModel = new GameObject(new Vector3(0, 0, 0), false);
            intercomModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(intercomModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            intercomModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.intercom, 1.0f);
            intercomModel.AddNewComponent<BoxCollider>();

        }
    }
}
