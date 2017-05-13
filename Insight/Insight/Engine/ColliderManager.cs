using Insight.Engine.Components;
using Insight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    class ColliderManager
    {
        bool isCollision;
        bool isCollisionDynamic;
        Vector3[] lastModelPosition;
        public event EventHandler<CollisionEventArgs> ObjectColided;
        List<GameObject> staticObjects;
        List<GameObject> dynamicObjects;

        public ColliderManager(List<GameObject> gameObjects)
        {
            isCollision = false;
            isCollisionDynamic = false;
            lastModelPosition = new Vector3[MainScene.GetGameObjects().Count];
            staticObjects = new List<GameObject>();
            dynamicObjects = new List<GameObject>();
            foreach (GameObject gameObject in MainScene.GetGameObjects())
            {
                if (gameObject.IsDynamic())
                {
                    dynamicObjects.Add(gameObject);
                }
                else
                {
                    staticObjects.Add(gameObject);
                }
            }
        }

        public void Update()
        {
            for (int j = 0; j < dynamicObjects.Count; j++)
            {
                if (j + 1 < dynamicObjects.Count)
                    isCollisionDynamic = PreciseCollisionTest(dynamicObjects[j], dynamicObjects[j].GetComponent<MeshRenderer>().GetMatrix(),
                        dynamicObjects[j + 1], dynamicObjects[j + 1].GetComponent<MeshRenderer>().GetMatrix());

                if (isCollisionDynamic)
                {
                    if (j + 1 < dynamicObjects.Count)
                        OnObjectColided(dynamicObjects[j + 1]);
                }


                for (int k = j; k < staticObjects.Count; k++)
                {
                    if (staticObjects[k].GetComponent<MeshRenderer>() != null)
                    {
                        isCollision = PreciseCollisionTest(dynamicObjects[j],
                            dynamicObjects[j].GetComponent<MeshRenderer>().GetMatrix(),
                            staticObjects[k], staticObjects[k].GetComponent<MeshRenderer>().GetMatrix());
                    }
                    if (isCollision)
                    {
                        OnObjectColided(staticObjects[k]);
                    }
                }
            }




            //for (int j = 0; j < MainScene.GetGameObjects().Count; j++)
            //{
            //    for(int k = j; k < MainScene.GetGameObjects().Count; k++)
            //    {
            //        if((MainScene.GetGameObjects()[j] != MainScene.GetGameObjects()[k]) && MainScene.GetGameObjects()[j].IsDynamic())
            //        isCollision = PreciseCollisionTest(MainScene.GetGameObjects()[j], MainScene.GetGameObjects()[j].GetComponent<MeshRenderer>().GetMatrix(),
            //        MainScene.GetGameObjects()[k], MainScene.GetGameObjects()[k].GetComponent<MeshRenderer>().GetMatrix());

            //        if (isCollision)
            //        {
            //            if (MainScene.GetGameObjects()[j].IsDynamic())
            //                OnObjectColided(MainScene.GetGameObjects()[k]);

            //            //if (MainScene.GetGameObjects()[k] != MainScene.GetGameObjects()[j])
            //            //    if (MainScene.GetGameObjects()[k].IsDynamic())
            //            //        OnObjectColided(lastModelPosition[k]);
            //        }

            //    }
            //}
        }

        private bool OverallCollisionTest(GameObject object1, Matrix world1, GameObject object2, Matrix world2)
        {
            if (object1.GetComponent<Collider>() is SphereCollider && object2.GetComponent<Collider>() is SphereCollider)
            {
                BoundingSphere origSphere1 = object1.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere1 = Collider.TransformBoundingSphere(origSphere1, world1);

                BoundingSphere origSphere2 = object2.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere2 = Collider.TransformBoundingSphere(origSphere2, world2);

                bool collision = sphere1.Intersects(sphere2);
                if (collision)
                {
                    Debug.WriteLine("Overall collision");
                }
                else
                {
                    //Debug.WriteLine("nope");
                }

                return collision;
            }
            else if (object1.GetComponent<Collider>() is BoxCollider && object2.GetComponent<Collider>() is BoxCollider)
            {
                BoundingSphere origSphere1 = object1.GetComponent<BoxCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere1 = Collider.TransformBoundingSphere(origSphere1, world1);

                BoundingSphere origSphere2 = object2.GetComponent<BoxCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere2 = Collider.TransformBoundingSphere(origSphere2, world2);

                bool collision = sphere1.Intersects(sphere2);
                if (collision)
                {
                    Debug.WriteLine("Overall collision");
                }
                else
                {
                    Debug.WriteLine("nope");
                }

                return collision;
            }
            //else if (object1.GetComponent<Collider>() is BoxCollider && object2.GetComponent<Collider>() is SphereCollider)
            //{
            //    BoundingSphere origSphere1 = object1.GetComponent<BoxCollider>().GetCompleteBoundingSphere();
            //    BoundingSphere sphere1 = Collider.TransformBoundingSphere(origSphere1, world1);

            //    BoundingSphere origSphere2 = object2.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
            //    BoundingSphere sphere2 = Collider.TransformBoundingSphere(origSphere2, world2);

            //    bool collision = sphere1.Intersects(sphere2);
            //    if (collision)
            //    {
            //        Debug.WriteLine("Overall collision");
            //    }
            //    else
            //    {
            //        Debug.WriteLine("nope");
            //    }

            //    return collision;
            //}
            else if (object1.GetComponent<Collider>() is SphereCollider && object2.GetComponent<Collider>() is BoxCollider)
            {
                BoundingSphere origSphere1 = object1.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere1 = Collider.TransformBoundingSphere(origSphere1, world1);

                BoundingSphere origSphere2 = object2.GetComponent<BoxCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere2 = Collider.TransformBoundingSphere(origSphere2, world2);

                bool collision = sphere1.Intersects(sphere2);
                if (collision)
                {
                    //Debug.WriteLine("Overall collision");
                }
                else
                {
                    //Debug.WriteLine("nope");
                    //if (object2.GetComponent<Collider>().IsTrigger)
                    //{
                    //    if (object1.GetComponent<Collider>().OnTriggerEnter)
                    //    {
                    //        object1.GetComponent<Collider>().OnTriggerExit = true;
                    //        object1.GetComponent<Collider>().OnTriggerEnter = false;
                    //    }
                    //}
                }

                return collision;
            }
            else if (object1.GetComponent<Collider>() is BoxCollider && object2.GetComponent<Collider>() is SphereCollider)
            {
                BoundingSphere origSphere1 = object1.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere1 = Collider.TransformBoundingSphere(origSphere1, world2);

                BoundingSphere origSphere2 = object2.GetComponent<BoxCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere2 = Collider.TransformBoundingSphere(origSphere2, world1);

                bool collision = sphere1.Intersects(sphere2);
                if (collision)
                {
                    //Debug.WriteLine("Overall collision");
                }
                else
                {
                    //Debug.WriteLine("nope");
                    //if (object2.GetComponent<Collider>().IsTrigger)
                    //{
                    //    if (object1.GetComponent<Collider>().OnTriggerEnter)
                    //    {
                    //        object1.GetComponent<Collider>().OnTriggerExit = true;
                    //        object1.GetComponent<Collider>().OnTriggerEnter = false;
                    //    }
                    //}
                }

                return collision;
            }


            return false;


        }

        private bool PreciseCollisionTest(GameObject object1, Matrix world1, GameObject object2, Matrix world2)
        {
            if (OverallCollisionTest(object1, world1, object2, world2) == false)
                return false;




            if (object1.GetComponent<Collider>() is SphereCollider && object2.GetComponent<Collider>() is SphereCollider)
            {
                //BoundingSphere[] object1Colliders = object1.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();
                //BoundingSphere[] object2Colliders = object2.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();

                //bool collision = false;

                //for (int i = 0; i < object1Colliders.Length; i++)
                //    for (int j = 0; j < object2Colliders.Length; j++)
                //        if (object1Colliders[i].Intersects(object2Colliders[j]))
                //        {
                //            Debug.WriteLine("Precise collision");
                //            return true;
                //        }

                //return collision;

                Matrix[] model1Transforms = new Matrix[object1.GetComponent<MeshRenderer>().getModel().Bones.Count];
                object1.GetComponent<MeshRenderer>().getModel().CopyAbsoluteBoneTransformsTo(model1Transforms);
                BoundingSphere[] model1Spheres = new BoundingSphere[object1.GetComponent<MeshRenderer>().getModel().Meshes.Count];
                for (int i = 0; i < object1.GetComponent<MeshRenderer>().getModel().Meshes.Count; i++)
                {
                    ModelMesh mesh = object1.GetComponent<MeshRenderer>().getModel().Meshes[i];
                    BoundingSphere origSphere = mesh.BoundingSphere;
                    Matrix trans = model1Transforms[mesh.ParentBone.Index] * world1;
                    BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                    model1Spheres[i] = transSphere;
                }


                Matrix[] model2Transforms = new Matrix[object2.GetComponent<MeshRenderer>().getModel().Bones.Count];
                object2.GetComponent<MeshRenderer>().getModel().CopyAbsoluteBoneTransformsTo(model2Transforms);
                BoundingSphere[] model2Spheres = new BoundingSphere[object2.GetComponent<MeshRenderer>().getModel().Meshes.Count];
                for (int i = 0; i < object2.GetComponent<MeshRenderer>().getModel().Meshes.Count; i++)
                {
                    ModelMesh mesh = object2.GetComponent<MeshRenderer>().getModel().Meshes[i];
                    BoundingSphere origSphere = mesh.BoundingSphere;
                    Matrix trans = model2Transforms[mesh.ParentBone.Index] * world2;
                    BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                    model2Spheres[i] = transSphere;
                }

                bool collision = false;

                for (int i = 0; i < model1Spheres.Length; i++)
                    for (int j = 0; j < model2Spheres.Length; j++)
                        if (model1Spheres[i].Intersects(model2Spheres[j]))
                        {
                            Debug.WriteLine("Precise collision");
                            return true;
                        }

                return collision;

            }
            else if (object1.GetComponent<Collider>() is BoxCollider && object2.GetComponent<Collider>() is BoxCollider)
            {
                BoundingBox[] object1Colliders = object1.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();
                BoundingBox[] object2Colliders = object2.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();

                bool collision = true;

                for (int i = 0; i < object1Colliders.Length; i++)
                    for (int j = 0; j < object2Colliders.Length; j++)
                        if (object1Colliders[i].Intersects(object2Colliders[j]))
                        {
                            Debug.WriteLine("Precise collision");
                            return true;
                        }

                return collision;
            }
            //else if (object1.GetComponent<Collider>() is BoxCollider && object2.GetComponent<Collider>() is SphereCollider)
            //{
            //    BoundingBox[] object1Colliders = object1.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();
            //    BoundingSphere[] object2Colliders = object2.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();

            //    bool collision = false;

            //    for (int i = 0; i < object1Colliders.Length; i++)
            //        for (int j = 0; j < object2Colliders.Length; j++)
            //            if (object1Colliders[i].Intersects(object2Colliders[j]))
            //            {
            //                Debug.WriteLine("Precise collision");
            //                return true;
            //            }

            //    return collision;
            //}
            else if (object1.GetComponent<Collider>() is SphereCollider && object2.GetComponent<Collider>() is BoxCollider)
            {
                //BoundingSphere[] object1Colliders = object1.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();

                Matrix[] model1Transforms = new Matrix[object1.GetComponent<MeshRenderer>().getModel().Bones.Count];
                object1.GetComponent<MeshRenderer>().getModel().CopyAbsoluteBoneTransformsTo(model1Transforms);
                BoundingSphere[] model1Spheres = new BoundingSphere[object1.GetComponent<MeshRenderer>().getModel().Meshes.Count];
                for (int i = 0; i < object1.GetComponent<MeshRenderer>().getModel().Meshes.Count; i++)
                {
                    ModelMesh mesh = object1.GetComponent<MeshRenderer>().getModel().Meshes[i];
                    BoundingSphere origSphere = mesh.BoundingSphere;
                    Matrix trans = model1Transforms[mesh.ParentBone.Index] * world1;
                    BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                    model1Spheres[i] = transSphere;
                }

                BoundingBox[] object2Colliders = object2.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();
                //BoundingBox[] object2Colliders;
                //Matrix[] model2Transforms;
                //ModelMesh mesh2;

                //BoundingBox[] boundingBoxes = object2.GetComponent<BoxCollider>().GetBoundingBoxes();
                //model2Transforms = new Matrix[object2.GetComponent<MeshRenderer>().getModel().Bones.Count];
                //object2.GetComponent<MeshRenderer>().getModel().CopyAbsoluteBoneTransformsTo(model2Transforms);
                //object2Colliders = new BoundingBox[object2.GetComponent<MeshRenderer>().getModel().Meshes.Count];
                //for (int i = 0; i < object2.GetComponent<MeshRenderer>().getModel().Meshes.Count; i++)
                //{
                //    mesh2 = object2.GetComponent<MeshRenderer>().getModel().Meshes[i];
                //    Matrix trans = model2Transforms[mesh2.ParentBone.Index] * world1;
                //    object2Colliders[i] = BoxCollider.TransformBoundingBox(boundingBoxes[i], trans);
                //}

                bool collision = false;

                for (int i = 0; i < model1Spheres.Length; i++)
                    for (int j = 0; j < object2Colliders.Length; j++)
                        if (model1Spheres[i].Intersects(object2Colliders[j]))
                        {
                            //Debug.WriteLine("Precise collision");
                            return true;
                        }

                if (collision)
                {
                    Debug.WriteLine("Precise collision");
                }
                else
                {
                    if (object2.GetComponent<Collider>().IsTrigger)
                    {
                        if (object1.GetComponent<Collider>().OnTriggerEnter)
                        {
                            object1.GetComponent<Collider>().OnTriggerExit = true;
                            object1.OnTriggerExit(object2);
                            object1.GetComponent<Collider>().OnTriggerEnter = false;
                            object1.GetComponent<Collider>().OnTriggerExit = false;
                        }
                    }
                }

                return collision;
            }
            //else if (object1.GetComponent<Collider>() is BoxCollider && object2.GetComponent<Collider>() is SphereCollider)
            //{
            //    //BoundingSphere[] object1Colliders = object1.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();

            //    Matrix[] model1Transforms = new Matrix[object2.GetComponent<MeshRenderer>().getModel().Bones.Count];
            //    object2.GetComponent<MeshRenderer>().getModel().CopyAbsoluteBoneTransformsTo(model1Transforms);
            //    BoundingSphere[] model1Spheres = new BoundingSphere[object2.GetComponent<MeshRenderer>().getModel().Meshes.Count];
            //    for (int i = 0; i < object2.GetComponent<MeshRenderer>().getModel().Meshes.Count; i++)
            //    {
            //        ModelMesh mesh = object2.GetComponent<MeshRenderer>().getModel().Meshes[i];
            //        BoundingSphere origSphere = mesh.BoundingSphere;
            //        Matrix trans = model1Transforms[mesh.ParentBone.Index] * world2;
            //        BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
            //        model1Spheres[i] = transSphere;
            //    }

            //    BoundingBox[] object2Colliders = object1.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();
            //    //BoundingBox[] object2Colliders;
            //    //Matrix[] model2Transforms;
            //    //ModelMesh mesh2;

            //    //BoundingBox[] boundingBoxes = object2.GetComponent<BoxCollider>().GetBoundingBoxes();
            //    //model2Transforms = new Matrix[object2.GetComponent<MeshRenderer>().getModel().Bones.Count];
            //    //object2.GetComponent<MeshRenderer>().getModel().CopyAbsoluteBoneTransformsTo(model2Transforms);
            //    //object2Colliders = new BoundingBox[object2.GetComponent<MeshRenderer>().getModel().Meshes.Count];
            //    //for (int i = 0; i < object2.GetComponent<MeshRenderer>().getModel().Meshes.Count; i++)
            //    //{
            //    //    mesh2 = object2.GetComponent<MeshRenderer>().getModel().Meshes[i];
            //    //    Matrix trans = model2Transforms[mesh2.ParentBone.Index] * world1;
            //    //    object2Colliders[i] = BoxCollider.TransformBoundingBox(boundingBoxes[i], trans);
            //    //}

            //    bool collision = false;

            //    for (int i = 0; i < model1Spheres.Length; i++)
            //        for (int j = 0; j < object2Colliders.Length; j++)
            //            if (model1Spheres[i].Intersects(object2Colliders[j]))
            //            {
            //                //Debug.WriteLine("Precise collision");
            //                return true;
            //            }

            //    if (collision)
            //    {
            //        Debug.WriteLine("Precise collision");
            //    }
            //    else
            //    {


            //    }

            //    return collision;
            //}

            //BoundingSphere[] object1Colliders = object1.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();
            //BoundingSphere[] object2Colliders = object2.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();

            //BoundingBox[] object1Colliders = object1.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();
            //BoundingBox[] object2Colliders = object2.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();


            return false;
        }

        private bool RayCollisionTest(GameObject gameobject, Matrix world, Vector3 lastPosition, Vector3 currectPosition)
        {
            BoundingSphere objectSphere = gameobject.GetComponent<BoxCollider>().GetCompleteBoundingSphere();
            BoundingSphere transSphere = Collider.TransformBoundingSphere(objectSphere, world);

            Vector3 direction = currectPosition - lastPosition;
            float distanceCovered = direction.Length();
            direction.Normalize();

            Ray ray = new Ray(lastPosition, direction);

            bool collision = false;
            float? intersection = ray.Intersects(transSphere);
            if (intersection != null)
                if (intersection <= distanceCovered)
                    collision = true;

            return collision;
        }

        protected virtual void OnObjectColided(GameObject gameObject)
        {
            if (ObjectColided != null)
                ObjectColided(this, new CollisionEventArgs() { GameObject = gameObject });
        }
    }
}
