﻿using Insight.Engine.Components;
using Insight.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs
{
    class AmmoPCMark : Prefab
    {
        public GameObject pcModel;
        GameObject triggerModel;
        private GameObject light;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            pcModel = new GameObject(new Vector3(0, 0, 0), false);
            triggerModel = new GameObject(new Vector3(0, 0, 0), false);
            light = new GameObject(new Vector3(0, 1f, 0), false);
            light.AddNewComponent<Light>();
            light.GetComponent<Light>().Color = Color.Green;
            light.GetComponent<Light>().Attenuation = 0.65f;
            light.GetComponent<Light>().Intensity = 5;


            pcModel.AddNewComponent<MeshRenderer>();
            triggerModel.AddNewComponent<MeshRenderer>();
            triggerModel.GetComponent<MeshRenderer>().IsVisible = false;


            prefabGameObjects.Add(light);
            prefabGameObjects.Add(pcModel);
            prefabGameObjects.Add(triggerModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            pcModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.ammo_pc, 0.5f);
            pcModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/zieloneSwiatelko/ammo-pc_DefaultMaterial_AO");
            pcModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/zieloneSwiatelko/ammo-pc_DefaultMaterial_MetallicSmoothness");
            pcModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/zieloneSwiatelko/ammo-pc_DefaultMaterial_Normal");
            pcModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/zieloneSwiatelko/ammo-pc_DefaultMaterial_AlbedoTransparency");
            triggerModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.dispensertrigger, 1.0f);
            pcModel.AddNewComponent<BoxCollider>();
            triggerModel.AddNewComponent<BoxCollider>();
            triggerModel.GetComponent<BoxCollider>().IsTrigger = true;
            triggerModel.Transform.Rotation = new Vector3(0);
            triggerModel.AddNewComponent<DispenserTriggerControllerMark>();
            triggerModel.GetComponent<DispenserTriggerControllerMark>().dispenser = pcModel;
            triggerModel.GetComponent<DispenserTriggerControllerMark>().content = content;
            triggerModel.GetComponent<DispenserTriggerControllerMark>().light = light;
        }
    }
}
