using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Components
{
    class BoxCollider : Component
    {
        BoundingBox box;
        VertexPositionColor[] primitiveList;
        Vector3[] corners;
        Vector3 pos;
        Model model;
        Vector3 rotation;

        public short[] bBoxIndices = {
            0, 1, 1, 2, 2, 3, 3, 0, // Front edges
            4, 5, 5, 6, 6, 7, 7, 4, // Back edges
            0, 4, 1, 5, 2, 6, 3, 7 // Side edges connecting front and back
        };

        public BoxCollider(GameObject gameObject) :base(gameObject)
        {
            pos = gameObject.Transform.Position;
            model = gameObject.GetComponent<MeshRenderer>().getModel();
            //temporary Vector3 values in box
            box = new BoundingBox(gameObject.Transform.Position - new Vector3(2, 0, 0), gameObject.Transform.Position + new Vector3(0, 2, 2));
            rotation = gameObject.Transform.Rotation;
            corners = box.GetCorners();
            primitiveList = new VertexPositionColor[corners.Length];
            for (int i = 0; i < corners.Length; i++)
            {
                primitiveList[i] = new VertexPositionColor(corners[i], Color.Red);
            }
        }

        public void Update(BoundingBox referenceBox)
        {

            corners = box.GetCorners();
            for (int i = 0; i < corners.Length; i++)
            {
                primitiveList[i] = new VertexPositionColor(corners[i], Color.Red);
            }         
        }

        public bool ProcessCollisions(BoundingBox otherBox, float dx, float dz)
        {
            // box = new BoundingBox(new Vector3(pos.X - size / 2 + dx, pos.Y - 40, pos.Z+15 - size / 2 + dz), new Vector3(pos.X + size / 2 + dx, pos.Y-30 + size, pos.Z-30 + size / 2 + dz));
            box.Min = new Vector3(pos.X - 10 + dx, pos.Y - 40, pos.Z + 15 - 10 + dz);
            box.Max = new Vector3(pos.X + 10 + dx, pos.Y - 30 + 10, pos.Z - 30 + 10 / 2 + dz);
            if (box.Intersects(otherBox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public VertexPositionColor[] GetPrimitiveList()
        {
            return primitiveList;
        }

        public void Draw(Matrix projection, GraphicsDeviceManager graphics, Matrix view)
        {
            BasicEffect boxEffect = new BasicEffect(graphics.GraphicsDevice);
            boxEffect.World = Matrix.Identity;
            boxEffect.View = view;
            boxEffect.Projection = projection;
            boxEffect.TextureEnabled = false;

            foreach (EffectPass pass in boxEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserIndexedPrimitives(
                PrimitiveType.LineList, gameObject.GetComponent<BoxCollider>().GetPrimitiveList(), 0, 8,
                gameObject.GetComponent<BoxCollider>().bBoxIndices, 0, 12);
            }
        }
    }
}
