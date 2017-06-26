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
    class BigMachine : Prefab
    {
        GameObject machineModel;
        GameObject machineCollider;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            machineModel = new GameObject(new Vector3(0, 0, 0), false);
            machineModel.AddNewComponent<MeshRenderer>();
            machineCollider = new GameObject(new Vector3(0, 0, 0), false);
            machineCollider.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(machineModel);
            prefabGameObjects.Add(machineCollider);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            machineModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.bigMachine, 1.0f);
            machineModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/bigMachine_1stRoom_DefaultMaterial_AlbedoTransparency");
            machineModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/bigMachine_1stRoom_DefaultMaterial_Normal");
            machineModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/bigMachine_1stRoom_DefaultMaterial_AO");
            machineModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/bigMachine_1stRoom_DefaultMaterial_MetallicSmoothness");

            machineCollider.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.bigMachineCollider, 1.0f);
            machineCollider.AddNewComponent<BoxCollider>();
            //machineModel.AddNewComponent<BoxCollider>();
            
        }
    }
}
