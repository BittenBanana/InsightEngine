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
    class CornerRightRotated : Prefab
    {
        GameObject cornerModel;
        GameObject cornerCollider;
        GameObject floor;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            cornerModel = new GameObject(new Vector3(0, 0, 0), false);
            cornerCollider = new GameObject(new Vector3(0, 0, 0), false);
            floor = new GameObject(new Vector3(0, 0, 0), false);



            cornerModel.AddNewComponent<MeshRenderer>();
            cornerCollider.AddNewComponent<MeshRenderer>();
            floor.AddNewComponent<MeshRenderer>();
            floor.GetComponent<MeshRenderer>().IsVisible = false;
            cornerCollider.GetComponent<MeshRenderer>().IsVisible = false;




            prefabGameObjects.Add(cornerModel);
            prefabGameObjects.Add(cornerCollider);
            prefabGameObjects.Add(floor);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            cornerModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.cor_corn_lt, 1.0f);
            cornerModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/cor-corn-lt_DefaultMaterial_AlbedoTransparency");
            cornerModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/cor-corn-lt_DefaultMaterial_Normal");
            cornerModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/cor-corn-lt_DefaultMaterial_AO");
            cornerModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/cor-corn-lt_DefaultMaterial_MetallicSmoothness");
            cornerCollider.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.cor_corn_col, 1.0f);
            floor.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.floorPlane, 1.0f);

            cornerCollider.AddNewComponent<BoxCollider>();
            floor.AddNewComponent<BoxCollider>();
            floor.physicLayer = Layer.Ground;

        }
    }
}
