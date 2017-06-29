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
    class CeilingLastRoom : Prefab
    {
        public GameObject wallModel;
        private GameObject light;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);

            wallModel.AddNewComponent<MeshRenderer>();

            light = new GameObject(new Vector3(0, 5, 0), false);
            light.AddNewComponent<Light>();
            light.GetComponent<Light>().Color = Color.LightYellow;
            light.GetComponent<Light>().Attenuation = 7.5f;

            prefabGameObjects.Add(light);
            prefabGameObjects.Add(wallModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            wallModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.lastRoomCeiling, 1.0f);
            wallModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/sufit_pokojKoncowy_DefaultMaterial_AlbedoTransparency");
            wallModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/sufit_pokojKoncowy_DefaultMaterial_Normal");
            wallModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/sufit_pokojKoncowy_DefaultMaterial_AO");
            wallModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/sufit_pokojKoncowy_DefaultMaterial_MetallicSmoothness");

            wallModel.AddNewComponent<BoxCollider>();

        }
    }
}
