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

        public GameObject triggerModel;
        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);
            leftDoorModel = new GameObject(new Vector3(0, 0, 0), false);
            rightDoorModel = new GameObject(new Vector3(0, 0, 0), false);
            frame = new GameObject(new Vector3(0, 0, 0), false);
            triggerModel = new GameObject(new Vector3(2.7f, 0, -0.4f), false);


            wallModel.AddNewComponent<MeshRenderer>();
            leftDoorModel.AddNewComponent<MeshRenderer>();
            rightDoorModel.AddNewComponent<MeshRenderer>();
            frame.AddNewComponent<MeshRenderer>();
            triggerModel.AddNewComponent<MeshRenderer>();
            triggerModel.GetComponent<MeshRenderer>().IsVisible = false;


            wallModel.AddNewComponent<DoorAnimation>();
            wallModel.GetComponent<DoorAnimation>().leftDoor = leftDoorModel;
            wallModel.GetComponent<DoorAnimation>().rightDoor = rightDoorModel;
            prefabGameObjects.Add(wallModel);
            prefabGameObjects.Add(leftDoorModel);
            prefabGameObjects.Add(rightDoorModel);
            prefabGameObjects.Add(frame);
            prefabGameObjects.Add(triggerModel);
            base.Initialize(position);
        }

        public override void Initialize(Vector3 position, Vector3 rot)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);
            leftDoorModel = new GameObject(new Vector3(0, 0, 0), false);
            rightDoorModel = new GameObject(new Vector3(0, 0, 0), false);
            frame = new GameObject(new Vector3(0, 0, 0), false);
            triggerModel = new GameObject(new Vector3(0, 0, 0), false);


            wallModel.AddNewComponent<MeshRenderer>();
            leftDoorModel.AddNewComponent<MeshRenderer>();
            rightDoorModel.AddNewComponent<MeshRenderer>();
            frame.AddNewComponent<MeshRenderer>();
            triggerModel.AddNewComponent<MeshRenderer>();
            triggerModel.GetComponent<MeshRenderer>().IsVisible = false;


            wallModel.AddNewComponent<DoorAnimation>();
            wallModel.GetComponent<DoorAnimation>().leftDoor = leftDoorModel;
            wallModel.GetComponent<DoorAnimation>().rightDoor = rightDoorModel;
            prefabGameObjects.Add(wallModel);
            prefabGameObjects.Add(leftDoorModel);
            prefabGameObjects.Add(rightDoorModel);
            prefabGameObjects.Add(frame);
            prefabGameObjects.Add(triggerModel);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            wallModel.LoadContent(content, ContentModels.Instance.door_wall_5x6, 1.0f);
            wallModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/wall-5x6_DefaultMaterial_AlbedoTransparency");
            wallModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/wall-5x6_DefaultMaterial_Normal");
            wallModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/wall-5x6_DefaultMaterial_AO");
            wallModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/wall-5x6_DefaultMaterial_MetallicSmoothness");

            leftDoorModel.LoadContent(content, ContentModels.Instance.door_l_wing, 1.0f);
            leftDoorModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/substance painter_DefaultMaterial_AlbedoTransparency");
            leftDoorModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/substance painter_DefaultMaterial_Normal");
            leftDoorModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/substance painter_DefaultMaterial_AO");
            leftDoorModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/substance painter_DefaultMaterial_MetallicSmoothness");

            rightDoorModel.LoadContent(content, ContentModels.Instance.door_r_wing, 1.0f);
            rightDoorModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/substance painter_DefaultMaterial_AlbedoTransparency");
            rightDoorModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/substance painter_DefaultMaterial_Normal");
            rightDoorModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/substance painter_DefaultMaterial_AO");
            rightDoorModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/substance painter_DefaultMaterial_MetallicSmoothness");

            frame.LoadContent(content, ContentModels.Instance.door_frame, 1.0f);
            frame.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/substance painter_DefaultMaterial_AlbedoTransparency");
            frame.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/substance painter_DefaultMaterial_Normal");
            frame.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/substance painter_DefaultMaterial_AO");
            frame.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/substance painter_DefaultMaterial_MetallicSmoothness");

            wallModel.AddNewComponent<BoxCollider>();
            leftDoorModel.AddNewComponent<BoxCollider>();
            rightDoorModel.AddNewComponent<BoxCollider>();
            //frame.AddNewComponent<BoxCollider>();

            triggerModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.dispensertrigger, 5.0f);
            triggerModel.AddNewComponent<BoxCollider>();
            triggerModel.GetComponent<BoxCollider>().IsTrigger = true;
            triggerModel.Transform.Rotation = new Vector3(0);
            triggerModel.AddNewComponent<DoorTrigger>();
            triggerModel.GetComponent<DoorTrigger>().targetAnimation = wallModel.GetComponent<DoorAnimation>();
            base.LoadContent(content);
        }
    }
}
