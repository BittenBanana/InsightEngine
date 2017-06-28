using Insight.Engine.Components;
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
    class Intercom : Prefab
    {
        GameObject intercomModel;
        GameObject trigger;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            intercomModel = new GameObject(new Vector3(0, 0, 0), false);
            trigger = new GameObject(new Vector3(0, 0, 0), false);

            intercomModel.AddNewComponent<MeshRenderer>();
            trigger.AddNewComponent<MeshRenderer>();
            trigger.GetComponent<MeshRenderer>().IsVisible = false;

            prefabGameObjects.Add(intercomModel);
            prefabGameObjects.Add(trigger);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            intercomModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.intercom, 1.0f);
            intercomModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/intercom_DefaultMaterial_AlbedoTransparency");
            intercomModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/intercom_DefaultMaterial_AO");
            intercomModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/intercom_DefaultMaterial_MetallicSmoothness");
            intercomModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/intercom_DefaultMaterial_Normal");
            intercomModel.AddNewComponent<BoxCollider>();

            trigger.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.dispensertrigger, 1.0f);
            
            trigger.AddNewComponent<BoxCollider>();
            trigger.GetComponent<BoxCollider>().IsTrigger = true;
            trigger.Transform.Rotation = new Vector3(0);
            trigger.AddNewComponent<IntercomController>();
        }

        public void SetDoorsToTrigger(GameObject doors)
        {
            trigger.GetComponent<IntercomController>().doors = doors;
        }
    }
}
