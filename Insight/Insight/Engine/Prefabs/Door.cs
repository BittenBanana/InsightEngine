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
    class Door : Prefab
    {
        GameObject doorModel;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            doorModel = new GameObject(new Vector3(0, 0, 0), false);

            doorModel.AddNewComponent<MeshRenderer>();



            prefabGameObjects.Add(doorModel);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {

            doorModel.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/wall5x5withDoor", 1.0f);

            doorModel.AddNewComponent<BoxCollider>();

        }
    }
}
