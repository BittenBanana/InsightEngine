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
    class RoomFloorSmallerRotated : Prefab
    {
        GameObject corridorModel;
        GameObject floor;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            corridorModel = new GameObject(new Vector3(0, 0, 0), false);
            floor = new GameObject(new Vector3(0, 0, 0), false);



            corridorModel.AddNewComponent<MeshRenderer>();
            floor.AddNewComponent<MeshRenderer>();
            floor.GetComponent<MeshRenderer>().IsVisible = false;



            prefabGameObjects.Add(corridorModel);
            prefabGameObjects.Add(floor);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {

            corridorModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.f_3x5_rotated, 1.0f);
            corridorModel.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/f-3x5_DefaultMaterial_AlbedoTransparency");
            corridorModel.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/f-3x5_DefaultMaterial_Normal");
            corridorModel.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/f-3x5_DefaultMaterial_AO");
            corridorModel.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/f-3x5_DefaultMaterial_MetallicSmoothness");
            floor.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.floorPlane, 1.0f);
            floor.AddNewComponent<BoxCollider>();
            floor.physicLayer = Layer.Ground;
        }
    }
}
