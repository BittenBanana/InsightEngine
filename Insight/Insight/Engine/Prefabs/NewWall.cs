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
    class NewWall : Prefab
    {
        public GameObject wallModel;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            wallModel = new GameObject(new Vector3(0, 0, 0), false);

            wallModel.AddNewComponent<MeshRenderer>();



            prefabGameObjects.Add(wallModel);
            base.Initialize(position);
        }

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

            wallModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.newWall, 1.0f);
            wallModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/w-5x5_DefaultMaterial_AlbedoTransparency");
            wallModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/w-5x5_DefaultMaterial_AO");
            wallModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/w-5x5_DefaultMaterial_MetallicSmoothness");
            wallModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/w-5x5_DefaultMaterial_Normal");

        }
    }
}
