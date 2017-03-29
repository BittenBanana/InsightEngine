using Insight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        BoundingBox[] boundingBoxes;
        Matrix[] transforms;
        Vector3[] lastPositionMin, lastPositionMax;
        GameObject gameObject;

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
            this.gameObject = gameObject;
            // Set up model data
            boundingBoxes = new BoundingBox[model.Meshes.Count];

            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            int i = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix meshTransform = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationX(gameObject.Transform.Rotation.X) * Matrix.CreateRotationY(gameObject.Transform.Rotation.Y) * Matrix.CreateRotationZ(gameObject.Transform.Rotation.Z) * Matrix.CreateTranslation(gameObject.Transform.Position);
                boundingBoxes[i] = BuildBoundingBox(mesh, meshTransform);
                i++;
            }

            lastPositionMin = new Vector3[boundingBoxes.Length];
            lastPositionMax = new Vector3[boundingBoxes.Length];
        }
        #endregion


        private BoundingBox BuildBoundingBox(ModelMesh mesh, Matrix meshTransform)
        {
            //pos = gameObject.Transform.Position;

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
            BoundingBox box = new BoundingBox(new Vector3(meshMin.X, meshMin.Y, meshMin.Z), new Vector3(meshMax.X, meshMax.Y, meshMax.Z));

            return box;
        }

        public override void Update()
        {
            ProcessCollisions(MainScene.GetGameObjects());
            base.Update();
        }

        public bool ProcessCollisions(List<GameObject> gameObjects)
        {
            int i = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix meshTransform = transforms[mesh.ParentBone.Index]
                        * Matrix.CreateScale(gameObject.GetComponent<MeshRenderer>().GetScale())
                        * Matrix.CreateFromQuaternion(gameObject.Transform.quaterion)
                        * Matrix.CreateTranslation(gameObject.Transform.Position)
                        * Matrix.CreateTranslation(gameObject.Transform.origin);
                boundingBoxes[i] = BuildBoundingBox(mesh, meshTransform);
                lastPositionMin[i] = boundingBoxes[i].Min;
                lastPositionMax[i] = boundingBoxes[i].Max;
                i++;
            }

            i = 0;
            
            foreach (GameObject otherBox in gameObjects)
            {
                if(otherBox != this.gameObject)
                {
                    foreach (BoundingBox otherBoxCol in otherBox.GetComponent<BoxCollider>().boundingBoxes)
                    {
                        i = 0;
                        foreach (BoundingBox box in this.boundingBoxes)
                        {
                            if (box.Intersects(otherBoxCol))
                            {
                                boundingBoxes[i].Min = lastPositionMin[i];
                                boundingBoxes[i].Max = lastPositionMax[i];
                                Debug.WriteLine("yuuuuuuuuuuuup");
                                return true;
                            }
                            else
                            {
                                i++;
                                return false;
                            }
                        }

                    }
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
                //boxEffect.World = Matrix.Identity;
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

                //Array.Clear(primitiveList, 0, corners.Length);
                //Array.Clear(corners, 0, box.GetCorners().Length);


            }
        }
    }
}
