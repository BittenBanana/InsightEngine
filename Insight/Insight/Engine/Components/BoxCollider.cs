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
        #region Fields
        VertexPositionColor[] primitiveList;
        Vector3[] corners;
        Vector3 pos;
        Model model;
        Vector3 rotation;
        List<BoundingBox> boundingBoxes;
        Matrix[] transforms;
        float scale;

        public short[] bBoxIndices = {
            0, 1, 1, 2, 2, 3, 3, 0, // Front edges
            4, 5, 5, 6, 6, 7, 7, 4, // Back edges
            0, 4, 1, 5, 2, 6, 3, 7 // Side edges connecting front and back
        };
        #endregion

        #region Contructors
        public BoxCollider(GameObject gameObject) :base(gameObject)
        {
            pos = gameObject.Transform.Position;
            model = gameObject.GetComponent<MeshRenderer>().getModel();
            rotation = gameObject.Transform.Rotation;

            // Set up model data
            boundingBoxes = new List<BoundingBox>();

            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix meshTransform = transforms[mesh.ParentBone.Index];
                boundingBoxes.Add(BuildBoundingBox(mesh, meshTransform));
            }
        }
        #endregion


        private BoundingBox BuildBoundingBox(ModelMesh mesh, Matrix meshTransform)
        {
            pos = gameObject.Transform.Position;
            scale = gameObject.GetComponent<MeshRenderer>().GetScale();

            // Create initial variables to hold min and max xyz values for the mesh
            Vector3 meshMax = new Vector3(float.MinValue);
            Vector3 meshMin = new Vector3(float.MaxValue);

            foreach (ModelMeshPart part in mesh.MeshParts)
            {
                // The stride is how big, in bytes, one vertex is in the vertex buffer
                // We have to use this as we do not know the make up of the vertex
                int stride = part.VertexBuffer.VertexDeclaration.VertexStride;

                VertexPositionNormalTexture[] vertexData = new VertexPositionNormalTexture[part.NumVertices];
                part.VertexBuffer.GetData(part.VertexOffset * stride, vertexData, 0, part.NumVertices, stride);

                // Find minimum and maximum xyz values for this mesh part
                Vector3 vertPosition = new Vector3();

                for (int i = 0; i < vertexData.Length; i++)
                {
                    vertPosition = vertexData[i].Position;

                    // update our values from this vertex
                    meshMin = Vector3.Min(meshMin, vertPosition);
                    meshMax = Vector3.Max(meshMax, vertPosition);
                }
            }

            // transform by mesh bone matrix
            meshMin = Vector3.Transform(meshMin, meshTransform);
            meshMax = Vector3.Transform(meshMax, meshTransform);


            // Create the bounding box
            BoundingBox box = new BoundingBox(new Vector3(meshMin.X * scale + pos.X, meshMin.Y * scale + pos.Y, meshMin.Z * scale + pos.Z), new Vector3(meshMax.X * scale + pos.X, meshMax.Y * scale + pos.Y, meshMax.Z * scale + pos.Z));

            return box;
        }

        private BoundingBox Scale(float scale, BoundingBox b)
        {
            //Get delta values
            float dx = Math.Abs(b.Max.X - b.Min.X);
            float dy = Math.Abs(b.Max.Y - b.Min.Y);
            float dz = Math.Abs(b.Max.Z - b.Min.Z);

            //get new delta values
            float newdx = dx * scale;
            float newdy = dy * scale;
            float newdz = dz * scale;

            //new max vector
            //oldvalue - removed delta, of course divided by 2(half for max and half for min).
            Vector3 newMax = new Vector3(b.Max.X - ((dx - newdx) / 2),
                                         b.Max.Y - ((dy - newdy) / 2),
                                         b.Max.Z - ((dz - newdz) / 2));

            //new min vector
            //oldvalue + removed delta, of course divided by 2(half for max and half for min).
            Vector3 newMin = new Vector3(b.Min.X + ((dx - newdx) / 2),
                                         b.Min.Y + ((dy - newdy) / 2),
                                         b.Min.Z + ((dz - newdz) / 2));

            BoundingBox box = new BoundingBox(newMin, newMax);
            return box;
        }

        public override void Update()
        {
            ProcessCollisions(new BoundingBox());

            base.Update();
        }

        public bool ProcessCollisions(BoundingBox otherBox)
        {
            int i = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix meshTransform = transforms[mesh.ParentBone.Index];
                boundingBoxes[i] = BuildBoundingBox(mesh, meshTransform);
                i++;
            }


            foreach (BoundingBox box in boundingBoxes)
            {

                if (box.Intersects(otherBox))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public VertexPositionColor[] GetPrimitiveList()
        {
            return primitiveList;
        }

        public void Draw(Matrix projection, GraphicsDeviceManager graphics, Matrix view)
        {
            foreach (BoundingBox box in boundingBoxes)
            {
                corners = box.GetCorners();
                primitiveList = new VertexPositionColor[corners.Length];
                // Assign the 8 box vertices
                for (int i = 0; i < corners.Length; i++)
                {
                    primitiveList[i] = new VertexPositionColor(corners[i], Color.White);
                }

                /* Set your own effect parameters here */
                BasicEffect boxEffect = new BasicEffect(graphics.GraphicsDevice);
                boxEffect.World = Matrix.Identity;
                boxEffect.View = view;
                boxEffect.Projection = projection;
                boxEffect.TextureEnabled = false;

                // Draw the box with a LineList
                foreach (EffectPass pass in boxEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    graphics.GraphicsDevice.DrawUserIndexedPrimitives(
                        PrimitiveType.LineList, primitiveList, 0, 8,
                        bBoxIndices, 0, 12);
                }
            }
        }
    }
}
