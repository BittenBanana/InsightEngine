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
        GameObject floor3;
        GameObject floor4;
        public override void Initialize()
        {
            prefabGameObjects = new List<GameObject>();

            floor1 = new GameObject(new Vector3(0, 0, 0), false);
            floor2 = new GameObject(new Vector3(0, 0, 5), false);
            floor3 = new GameObject(new Vector3(5, 0, 0), false);
            floor4 = new GameObject(new Vector3(5, 0, 5), false);


            floor1.AddNewComponent<MeshRenderer>();
            floor2.AddNewComponent<MeshRenderer>();
            floor3.AddNewComponent<MeshRenderer>();
            floor4.AddNewComponent<MeshRenderer>();


            prefabGameObjects.Add(floor1);
            prefabGameObjects.Add(floor2);
            prefabGameObjects.Add(floor3);
            prefabGameObjects.Add(floor4);
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {

            floor1.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            floor2.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            floor3.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
            floor4.GetComponent<MeshRenderer>().Load(content, "floor5x5", 1.0f);
        }


    }
}
