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
    class CeilingSmallRoom : Prefab
    {
        GameObject wallModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);

            wallModel.AddNewComponent<MeshRenderer>();



            prefabGameObjects.Add(wallModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            wallModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.smallRoomCeiling, 1.0f);
            wallModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/sufit_malyPokoj_DefaultMaterial_AlbedoTransparency");
            wallModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/sufit_malyPokoj_DefaultMaterial_Normal");
            wallModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/sufit_malyPokoj_DefaultMaterial_AO");
            wallModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/sufit_malyPokoj_DefaultMaterial_MetallicSmoothness");

            wallModel.AddNewComponent<BoxCollider>();

        }
    }
}
