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
    class CorridorRotated : Prefab
    {
        GameObject corridorModel;
        GameObject floor;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            corridorModel = new GameObject(new Vector3(0, 0, 0), false);
            floor = new GameObject(new Vector3(0, 0, 0), false);



            corridorModel.AddNewComponent<MeshRenderer>();
            floor.AddNewComponent<MeshRenderer>();
            floor.GetComponent<MeshRenderer>().IsVisible = false;



            prefabGameObjects.Add(corridorModel);
            prefabGameObjects.Add(floor);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            corridorModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.cor_str_rt_g, 1.0f);
            corridorModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/corridor-straight_DefaultMaterial_AlbedoTransparency");
            corridorModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/corridor-straight_DefaultMaterial_Normal");
            corridorModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/corridor-straight_DefaultMaterial_AO");
            corridorModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/corridor-straight_DefaultMaterial_MetallicSmoothness");
            floor.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.floorPlane, 1.0f);

            corridorModel.AddNewComponent<BoxCollider>();
            floor.AddNewComponent<BoxCollider>();
            floor.physicLayer = Layer.Ground;

        }
    }
}
