using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Insight.Engine.Components;
using Insight.Scripts;

namespace Insight.Engine.Prefabs
{
    class AnimatedDoor : Prefab
    {
        GameObject wallModel;
        GameObject leftDoorModel;
        GameObject rightDoorModel;
        GameObject frame;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);
            leftDoorModel = new GameObject(new Vector3(0, 0, 0), false);
            rightDoorModel = new GameObject(new Vector3(0, 0, 0), false);
            frame = new GameObject(new Vector3(0, 0, 0), false);

            wallModel.AddNewComponent<MeshRenderer>();
            leftDoorModel.AddNewComponent<MeshRenderer>();
            rightDoorModel.AddNewComponent<MeshRenderer>();
            frame.AddNewComponent<MeshRenderer>();


            wallModel.AddNewComponent<DoorAnimation>();
            wallModel.GetComponent<DoorAnimation>().leftDoor = leftDoorModel;
            wallModel.GetComponent<DoorAnimation>().rightDoor = rightDoorModel;
            prefabGameObjects.Add(wallModel);
            prefabGameObjects.Add(leftDoorModel);
            prefabGameObjects.Add(rightDoorModel);
            prefabGameObjects.Add(frame);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            wallModel.LoadContent(content, "Models/Konrads/Enviroment/Door/wall-5x4", 1.0f);
            leftDoorModel.LoadContent(content, "Models/Konrads/Enviroment/Door/l-wing", 1.0f);
            rightDoorModel.LoadContent(content, "Models/Konrads/Enviroment/Door/r-wing", 1.0f);
            frame.LoadContent(content, "Models/Konrads/Enviroment/Door/frame", 1.0f);

            wallModel.AddNewComponent<BoxCollider>();
            leftDoorModel.AddNewComponent<BoxCollider>();
            rightDoorModel.AddNewComponent<BoxCollider>();
            //frame.AddNewComponent<BoxCollider>();

            base.LoadContent(content);
        }
    }
}
