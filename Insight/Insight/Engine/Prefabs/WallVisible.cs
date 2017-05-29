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
    class WallVisible : Prefab
    {
        GameObject wallModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);

            wallModel.AddNewComponent<MeshRenderer>();



            prefabGameObjects.Add(wallModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            wallModel.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/w-5x5-visible", 1.0f);

            wallModel.AddNewComponent<BoxCollider>();

        }
    }
}
