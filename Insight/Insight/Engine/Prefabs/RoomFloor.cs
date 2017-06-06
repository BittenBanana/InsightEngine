﻿using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs
{
    class RoomFloor : Prefab
    {
        GameObject corridorModel;
        GameObject floor;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            corridorModel = new GameObject(new Vector3(0, 0, 0), false);
            floor = new GameObject(new Vector3(0, 0, 0), false);



            corridorModel.AddNewComponent<MeshRenderer>();
            floor.AddNewComponent<MeshRenderer>();
            floor.GetComponent<MeshRenderer>().IsVisible = false;



            prefabGameObjects.Add(corridorModel);
            prefabGameObjects.Add(floor);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {

            corridorModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.f_5x5, 1.0f);
            floor.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.floorPlane, 1.0f);

            floor.AddNewComponent<BoxCollider>();
            floor.physicLayer = Layer.Ground;
        }
    }
}
