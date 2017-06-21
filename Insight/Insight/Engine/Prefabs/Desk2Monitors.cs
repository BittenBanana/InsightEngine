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
    class Desk2Monitors : Prefab
    {
        GameObject deskModel;

        public override void Initialize(Vector3 position, Vector3 rotation)
        {
            prefabGameObjects = new List<GameObject>();

            deskModel = new GameObject(new Vector3(0, 0, 0), false);
            deskModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(deskModel);
            base.Initialize(position, rotation);
        }

        public override void LoadContent(ContentManager content)
        {

            deskModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.desk2Monitors, 0.5f);
            deskModel.AddNewComponent<BoxCollider>();

        }
    }
}
