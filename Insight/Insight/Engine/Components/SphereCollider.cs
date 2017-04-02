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
            model = gameObject.GetComponent<MeshRenderer>().getModel();
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
            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            BoundingSphere[] spheres = new BoundingSphere[model.Meshes.Count];

            for (int i = 0; i < model.Meshes.Count; i++)
            {
                ModelMesh mesh = model.Meshes[i];
                BoundingSphere origSphere = mesh.BoundingSphere;
                Matrix trans = transforms[mesh.ParentBone.Index] * gameObject.GetComponent<MeshRenderer>().GetMatrix();
                BoundingSphere transSphere = TransformBoundingSphere(origSphere, trans);
                spheres[i] = transSphere;
            }

            return spheres;
        }

        public override void Update()
        {

            base.Update();
        }

        public static BoundingSphere TransformBoundingSphere(BoundingSphere originalBoundingSphere, Matrix transformationMatrix)
        {
            Vector3 trans;
            Vector3 scaling;
            Quaternion rot;
            transformationMatrix.Decompose(out scaling, out rot, out trans);

            float maxScale = scaling.X;
            if (maxScale < scaling.Y)
                maxScale = scaling.Y;
            if (maxScale < scaling.Z)
                maxScale = scaling.Z;

            float transformedSphereRadius = originalBoundingSphere.Radius * maxScale;
            Vector3 transformedSphereCenter = Vector3.Transform(originalBoundingSphere.Center, transformationMatrix);

            BoundingSphere transformedBoundingSphere = new BoundingSphere(transformedSphereCenter, transformedSphereRadius);

            return transformedBoundingSphere;
        }
    }
}
