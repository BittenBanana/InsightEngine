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
    class Column : Prefab
    {
        GameObject columnModel;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            columnModel = new GameObject(new Vector3(0, 0, 0), false);
            columnModel.AddNewComponent<MeshRenderer>();

            prefabGameObjects.Add(columnModel);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {

            columnModel.GetComponent<MeshRenderer>().Load(content, ContentModels.Instance.column, 1.0f);
            columnModel.AddNewComponent<BoxCollider>();

        }
    }
}
