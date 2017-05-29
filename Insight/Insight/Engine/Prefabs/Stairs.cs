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

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            stairsModel = new GameObject(new Vector3(0, 0, 0), false);

            stairsModel.AddNewComponent<MeshRenderer>();



            prefabGameObjects.Add(stairsModel);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {

            stairsModel.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/stairs", 1.0f);

            stairsModel.AddNewComponent<BoxCollider>();

        }
    }
}
