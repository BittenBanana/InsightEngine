using Insight.Engine.Components;
using Insight.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (item.physicLayer != Layer.IgnoreRaycast)
                {
                    BoxCollider bc = item.GetComponent<BoxCollider>();
                    SphereCollider sc = item.GetComponent<SphereCollider>();
                    if (bc != null)
                    {
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
                    if (sc != null)
                    {
                        foreach (var boundingSphere in sc.GetPreciseBoundingSpheres())
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
            if(go != null)
            {
                hit = new RaycastHit();
                hit.origin = origin;
                hit.point = origin + Vector3.Normalize(direction) * distance;
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
