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
    class CeilingBigRoom : Prefab
    {
        GameObject wallModel;
        private GameObject light;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);

            wallModel.AddNewComponent<MeshRenderer>();

            light = new GameObject(new Vector3(-10,5,-8), false);
            light.AddNewComponent<Light>();
            light.GetComponent<Light>().Color = Color.LightYellow;
            light.GetComponent<Light>().Attenuation = 12.5f;

            prefabGameObjects.Add(light);
            prefabGameObjects.Add(wallModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            wallModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.ceilingBogRoom, 1.0f);
            wallModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/sufit_pokojZMaszyna_DefaultMaterial_AlbedoTransparency");
            wallModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/sufit_pokojZMaszyna_DefaultMaterial_Normal");
            wallModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/sufit_pokojZMaszyna_DefaultMaterial_AO");
            wallModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/sufit_pokojZMaszyna_DefaultMaterial_MetallicSmoothness");

            wallModel.AddNewComponent<BoxCollider>();

        }
    }
}
