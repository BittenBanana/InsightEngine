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
    class BoxCollider : Collider
    {
        #region Fields
        VertexPositionColor[] primitiveList;
        Vector3[] corners;
        Vector3 pos;
        Model model;
        Vector3 rotation;
        public BoundingBox[] boundingBoxes;
        Matrix[] transforms;
        Vector3[] lastPositionMin, lastPositionMax;
        BoundingSphere completeBoundingSphere;

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
            boundingBoxes = new BoundingBox[model.Meshes.Count];

            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            int i = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix meshTransform = transforms[mesh.ParentBone.Index] * gameObject.GetComponent<MeshRenderer>().GetMatrix();
                boundingBoxes[i] = BuildBoundingBox(mesh, meshTransform);
                i++;
            }

            lastPositionMin = new Vector3[boundingBoxes.Length];
            lastPositionMax = new Vector3[boundingBoxes.Length];

            completeBoundingSphere = new BoundingSphere();
            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere origMeshSphere = mesh.BoundingSphere;
                BoundingSphere transMeshSphere = TransformBoundingSphere(origMeshSphere, transforms[mesh.ParentBone.Index]);
                completeBoundingSphere = BoundingSphere.CreateMerged(completeBoundingSphere, transMeshSphere);
            }
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

        public BoundingSphere GetCompleteBoundingSphere()
        {
            return completeBoundingSphere;
        }

        public override void Update()
        {
            //ProcessCollisions(MainScene.GetGameObjects());
            
            //Debug.WriteLine(boundingBoxes[0].Min);
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
                i++;
            }

            
                    



            //foreach (GameObject otherBox in gameObjects)
            //{
            //    if(otherBox != this.gameObject)
            //    {
            //        foreach (BoundingBox otherBoxCol in otherBox.GetComponent<BoxCollider>().boundingBoxes)
            //        {
            //            i = 0;
            //            foreach (BoundingBox box in this.boundingBoxes)
            //            {
            //                if (box.Intersects(otherBoxCol))
            //                {
            //                    boundingBoxes[i].Min = lastPositionMin[i];
            //                    boundingBoxes[i].Max = lastPositionMax[i];
            //                    Debug.WriteLine("yuuuuuuuuuuuup");
            //                    return true;
            //                }
            //                else
            //                {
            //                    i++;
            //                    return false;
            //                }
            //            }

            //        }
            //    }

            //}               


            return false;
        }

        public VertexPositionColor[] GetPrimitiveList()
        {
            return primitiveList;
        }

        public BoundingBox[] GetPreciseBoundingBoxes()
        {
            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            int i = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix meshTransform = transforms[mesh.ParentBone.Index]
                        * gameObject.GetComponent<MeshRenderer>().GetMatrix();
                //boundingBoxes[i] = BuildBoundingBox(mesh, meshTransform);
                //boundingBoxes[i] = TransformBoundingBox(boundingBoxes[i], meshTransform);
                i++;
            }

            return boundingBoxes;
        }

        public static BoundingBox TransformBoundingBox(BoundingBox origBox, Matrix matrix)
        {
            Vector3 origCorner1 = origBox.Min;
            Vector3 origCorner2 = origBox.Max;

            Vector3 transCorner1 = Vector3.Transform(origCorner1, matrix);
            Vector3 transCorner2 = Vector3.Transform(origCorner2, matrix);

            return new BoundingBox(transCorner1, transCorner2);
        }

        public static BoundingBox CreateBoxFromSphere(BoundingSphere sphere)
        {
            float radius = sphere.Radius;
            Vector3 outerPoint = new Vector3(radius, radius, radius);

            Vector3 p1 = sphere.Center + outerPoint;
            Vector3 p2 = sphere.Center - outerPoint;

            return new BoundingBox(p1, p2);
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

        public void DrawSphereSpikes(BoundingSphere sphere, GraphicsDevice device, Matrix worldMatrix, Matrix viewMatrix, Matrix projectionMatrix)
        {
            Vector3 up = sphere.Center + sphere.Radius * Vector3.Up;
            Vector3 down = sphere.Center + sphere.Radius * Vector3.Down;
            Vector3 right = sphere.Center + sphere.Radius * Vector3.Right;
            Vector3 left = sphere.Center + sphere.Radius * Vector3.Left;
            Vector3 forward = sphere.Center + sphere.Radius * Vector3.Forward;
            Vector3 back = sphere.Center + sphere.Radius * Vector3.Backward;

            VertexPositionColor[] sphereLineVertices = new VertexPositionColor[6];
            sphereLineVertices[0] = new VertexPositionColor(up, Color.White);
            sphereLineVertices[1] = new VertexPositionColor(down, Color.White);
            sphereLineVertices[2] = new VertexPositionColor(left, Color.White);
            sphereLineVertices[3] = new VertexPositionColor(right, Color.White);
            sphereLineVertices[4] = new VertexPositionColor(forward, Color.White);
            sphereLineVertices[5] = new VertexPositionColor(back, Color.White);

            BasicEffect basicEffect = new BasicEffect(device);

            basicEffect.World = worldMatrix;
            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;
            basicEffect.VertexColorEnabled = true;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserPrimitives(PrimitiveType.LineList, sphereLineVertices, 0, 3);
            }

            //DebugDraw debugDraw = new DebugDraw(device);

            //debugDraw.Begin(viewMatrix, projectionMatrix);
            //debugDraw.DrawWireSphere(sphere, Color.Yellow);
            //debugDraw.End();


        }
    }
}
