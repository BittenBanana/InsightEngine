using Insight.Engine.Components;
using Insight.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Engine
{
    static class Physics
    {
        private static Vector3 gravity = new Vector3(0, -9.81f, 0);
        public static Vector3 Gravity
        {
            get { return gravity; }
            private set { gravity = value; }
        }

        public class RaycastHit
        {
            public Vector3 origin;
            public Vector3 point;
            public Collider collider;
            public float distance;
            public Rigidbody rigidbody;
            public Transform transform;
        }

        public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hit)
        {

            Ray ray = new Ray(origin, direction);
            GameObject go = null;
            float distance = float.MaxValue;
            float? tempDistance = null;
            foreach (var item in SceneManager.Instance.GetGameObjectsFromCurrentScene())
            {
                if (item.physicLayer != Layer.Player)
                {
                    BoxCollider bc = item.GetComponent<BoxCollider>();
                    SphereCollider sc = item.GetComponent<SphereCollider>();
                    if (bc != null)
                    {
                        if (!bc.IsTrigger)
                        {
                            //if (ray.Intersects(bc.GetCompleteBoundingSphere()) != null)
                            foreach (var boundingBox in bc.GetPreciseBoundingBoxes())
                            {
                                tempDistance = ray.Intersects(boundingBox);
                                if (tempDistance != null)
                                {
                                    if (tempDistance < distance)
                                    {
                                        distance = (float)tempDistance;
                                        go = item;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (sc != null)
                    {
                        if (!sc.IsTrigger)
                        {
                            Matrix[] model1Transforms =
                                new Matrix[sc.gameObject.GetComponent<Renderer>().getModel().Bones.Count];
                            sc.gameObject.GetComponent<Renderer>().getModel()
                                .CopyAbsoluteBoneTransformsTo(model1Transforms);
                            BoundingSphere[] model1Spheres =
                                new BoundingSphere[sc.gameObject.GetComponent<Renderer>().getModel().Meshes.Count];
                            for (int i = 0; i < sc.gameObject.GetComponent<Renderer>().getModel().Meshes.Count; i++)
                            {
                                ModelMesh mesh = sc.gameObject.GetComponent<Renderer>().getModel().Meshes[i];
                                BoundingSphere origSphere = mesh.BoundingSphere;
                                Matrix trans = model1Transforms[mesh.ParentBone.Index] *
                                               sc.gameObject.GetComponent<Renderer>().GetMatrix();
                                BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                                model1Spheres[i] = transSphere;
                            }

                            //if (ray.Intersects(sc.GetCompleteBoundingSphere()) != null)
                            foreach (var boundingSphere in model1Spheres)
                            {
                                tempDistance = ray.Intersects(boundingSphere);
                                if (tempDistance != null)
                                {
                                    if (tempDistance < distance)
                                    {
                                        distance = (float)tempDistance;
                                        go = item;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (go != null)
            {
                hit = new RaycastHit();
                hit.origin = origin;
                hit.point = origin + direction * distance;
                hit.collider = go.GetComponent<Collider>();
                hit.distance = distance;
                hit.rigidbody = go.GetComponent<Rigidbody>();
                hit.transform = go.Transform;
                return true;
            }
            else
            {
                hit = null;
                return false;
            }
        }
    }
}
