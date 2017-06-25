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
    class Crate : Prefab
    {
        public GameObject crateModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            crateModel = new GameObject(new Vector3(0, 0, 0), false);
            crateModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(crateModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            crateModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.crate, 0.5f);
            crateModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/crate_DefaultMaterial_AlbedoTransparency");
            crateModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/crate_DefaultMaterial_AO");
            crateModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/crate_DefaultMaterial_MetallicSmoothness");
            crateModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/crate_DefaultMaterial_Normal");
            crateModel.AddNewComponent<BoxCollider>();
            crateModel.physicLayer = Layer.IgnoreRaycast;

        }
    }
}
