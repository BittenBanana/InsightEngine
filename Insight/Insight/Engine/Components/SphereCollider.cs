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
    class SphereCollider : Collider
    {
        List<BoundingSphere> boundingSpheres;
        Matrix[] transforms;
        Model model;
        Vector3 rotation;
        Vector3 pos;
        BoundingSphere completeBoundingSphere;

        public SphereCollider(GameObject gameObject) :base(gameObject)
        {
            model = gameObject.GetComponent<Renderer>().getModel();
            rotation = gameObject.Transform.Rotation;
            pos = gameObject.Transform.Position;
            boundingSpheres = new List<BoundingSphere>();

            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            completeBoundingSphere = new BoundingSphere();
            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere origMeshSphere = mesh.BoundingSphere;
                BoundingSphere transMeshSphere = TransformBoundingSphere(origMeshSphere, transforms[mesh.ParentBone.Index]);
                completeBoundingSphere = BoundingSphere.CreateMerged(completeBoundingSphere, transMeshSphere);
            }
        }

        public BoundingSphere GetCompleteBoundingSphere()
        {
            return completeBoundingSphere;
        }

        public BoundingSphere[] GetPreciseBoundingSpheres()
        {
            //transforms = new Matrix[model.Bones.Count];
           // model.CopyAbsoluteBoneTransformsTo(transforms);

            BoundingSphere[] spheres = new BoundingSphere[model.Meshes.Count];

            for (int i = 0; i < model.Meshes.Count; i++)
            {
                ModelMesh mesh = model.Meshes[i];
                BoundingSphere origSphere = mesh.BoundingSphere;
                Matrix trans = transforms[mesh.ParentBone.Index];
                BoundingSphere transSphere = TransformBoundingSphere(origSphere, trans);
                spheres[i] = transSphere;
            }

            return spheres;
        }

        public override void Update()
        {

            base.Update();
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
