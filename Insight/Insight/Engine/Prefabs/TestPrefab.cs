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
    class TestPrefab : Prefab
    {
        GameObject floor1;
        GameObject floor2;
        public override void Initialize()
        {
            prefabGameObjects = new List<GameObject>();

            floor1 = new GameObject(new Vector3(0, 0, 0), false);
            floor2 = new GameObject(new Vector3(0, 0, 5), false);
            

            floor1.AddNewComponent<MeshRenderer>();
            floor2.AddNewComponent<MeshRenderer>();


            prefabGameObjects.Add(floor1);
            prefabGameObjects.Add(floor2);
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {

            floor1.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            floor2.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
        }


    }
}
