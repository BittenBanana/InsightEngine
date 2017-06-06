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
        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            floor1 = new GameObject(new Vector3(0, 0, 0), false);
            floor2 = new GameObject(new Vector3(0, 0, 5), false);
            floor3 = new GameObject(new Vector3(0, 0, 10), false);
            floor4 = new GameObject(new Vector3(5, 0, 5), false);


            floor1.AddNewComponent<MeshRenderer>();
            floor2.AddNewComponent<MeshRenderer>();
            floor3.AddNewComponent<MeshRenderer>();
            //floor4.AddNewComponent<MeshRenderer>();

            


            prefabGameObjects.Add(floor1);
            prefabGameObjects.Add(floor2);
            prefabGameObjects.Add(floor3);
            //prefabGameObjects.Add(floor4);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {

            floor1.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.cor_str_rt_g, 1.0f);
            floor2.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.cor_str_rt_g, 1.0f);
            floor3.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.cor_corn_rt, 1.0f);
            //floor4.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/floor5x5", 1.0f);

            floor1.AddNewComponent<BoxCollider>();
            floor1.physicLayer = Layer.Ground;
            //floor2.AddNewComponent<BoxCollider>();
            //floor2.physicLayer = Layer.Ground;
            //floor3.AddNewComponent<BoxCollider>();
            //floor3.physicLayer = Layer.Ground;
            //floor4.AddNewComponent<BoxCollider>();
            //floor4.physicLayer = Layer.Ground;
        }


    }
}
