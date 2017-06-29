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
    class GlassBaseModel : Prefab
    {
        public GameObject columnModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            columnModel = new GameObject(new Vector3(0, 0, 0), false);
            columnModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(columnModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            columnModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.glassBaseModel, 1.0f);
            columnModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/szybaDol_DefaultMaterial_AlbedoTransparency");
            columnModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/szybaDol_DefaultMaterial_Normal");
            columnModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/szybaDol_DefaultMaterial_AO");
            columnModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/szybaDol_DefaultMaterial_MetallicSmoothness");
            columnModel.AddNewComponent<BoxCollider>();

        }
    }
}
