﻿using Insight.Engine.Components;
using Insight.Scenes;
using Insight.Scripts;
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
        public bool isCollision;
        bool isCollisionDynamic;
        Vector3[] lastModelPosition;
        public event EventHandler<CollisionEventArgs> ObjectColided;
        List<GameObject> staticObjects;
        List<GameObject> dynamicObjects;

        public ColliderManager(List<GameObject> gameObjects)
        {
            isCollision = false;
            isCollisionDynamic = false;
            lastModelPosition = new Vector3[gameObjects.Count];
            staticObjects = new List<GameObject>();
            dynamicObjects = new List<GameObject>();
            foreach (GameObject gameObject in gameObjects)
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

                dynamicObjects[j].Transform.prevPosition = dynamicObjects[j].Transform.Position;
                    
                if (j + 1 < dynamicObjects.Count)
                    isCollisionDynamic = PreciseCollisionTest(dynamicObjects[j], dynamicObjects[j].GetComponent<Renderer>().GetMatrix(),
                        dynamicObjects[j + 1], dynamicObjects[j + 1].GetComponent<Renderer>().GetMatrix());

                Rigidbody rb = dynamicObjects[j].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isGrounded = false;
                }

                if (isCollisionDynamic)
                {
                    if (j + 1 < dynamicObjects.Count)
                    {
                        ObjectColided += dynamicObjects[j].OnObjectColided;
                        ObjectColided += dynamicObjects[j+1].OnObjectColided;
                        OnObjectColided(dynamicObjects[j + 1]);
                        ObjectColided -= dynamicObjects[j].OnObjectColided;
                        ObjectColided -= dynamicObjects[j+1].OnObjectColided;
                    }
                        
                }

                
                for (int k = j; k < staticObjects.Count; k++)
                {
                    if (staticObjects[k].GetComponent<Renderer>() != null)
                    {
                        isCollision = PreciseCollisionTest(dynamicObjects[j],
                            dynamicObjects[j].GetComponent<Renderer>().GetMatrix(),
                            staticObjects[k], staticObjects[k].GetComponent<Renderer>().GetMatrix());
                    }
                    if (isCollision)
                    {
                        if(staticObjects[k].GetComponent<Collider>() != null)
                        {
                            if (staticObjects[k].GetComponent<Collider>().IsTrigger && dynamicObjects[j].physicLayer != Layer.Enemy)
                            {
                                ObjectColided += staticObjects[k].OnObjectColided;
                                OnObjectColided(dynamicObjects[j]);
                                ObjectColided -= staticObjects[k].OnObjectColided;
                            }
                            else
                            {
                                //dynamicObjects[j].collision = true;
                                ObjectColided += dynamicObjects[j].GetComponent<BoxController>().OnObjectColided;
                                ObjectColided += dynamicObjects[j].OnObjectColided;
                                OnObjectColided(staticObjects[k]);
                                ObjectColided -= dynamicObjects[j].OnObjectColided;
                                ObjectColided -= dynamicObjects[j].GetComponent<BoxController>().OnObjectColided;
                            }
                        }
                                               
                    }
                }
                //Debug.WriteLine(dynamicObjects[j].Transform.prevPosition + "     previous");
                //Debug.WriteLine(dynamicObjects[j].Transform.Position + "     current");
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
                    //Debug.WriteLine("Overall collision");
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
                    //Debug.WriteLine("Overall collision");
                }
                else
                {
                    //Debug.WriteLine("nope");
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
                    //if(object1.physicLayer == Layer.Player)
                    //    Debug.WriteLine("Overall collision");
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

                Matrix[] model1Transforms = new Matrix[object1.GetComponent<Renderer>().getModel().Bones.Count];
                object1.GetComponent<Renderer>().getModel().CopyAbsoluteBoneTransformsTo(model1Transforms);
                BoundingSphere[] model1Spheres = new BoundingSphere[object1.GetComponent<Renderer>().getModel().Meshes.Count];
                for (int i = 0; i < object1.GetComponent<Renderer>().getModel().Meshes.Count; i++)
                {
                    ModelMesh mesh = object1.GetComponent<Renderer>().getModel().Meshes[i];
                    BoundingSphere origSphere = mesh.BoundingSphere;
                    Matrix trans = model1Transforms[mesh.ParentBone.Index] * world1;
                    BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                    model1Spheres[i] = transSphere;
                    if(object1.physicLayer != Layer.DispenserTrigger)
                        model1Spheres[i].Radius = 0.1f;
                }


                Matrix[] model2Transforms = new Matrix[object2.GetComponent<Renderer>().getModel().Bones.Count];
                object2.GetComponent<Renderer>().getModel().CopyAbsoluteBoneTransformsTo(model2Transforms);
                BoundingSphere[] model2Spheres = new BoundingSphere[object2.GetComponent<Renderer>().getModel().Meshes.Count];
                for (int i = 0; i < object2.GetComponent<Renderer>().getModel().Meshes.Count; i++)
                {
                    ModelMesh mesh = object2.GetComponent<Renderer>().getModel().Meshes[i];
                    BoundingSphere origSphere = mesh.BoundingSphere;
                    origSphere.Radius -= .1f;
                    Matrix trans = model2Transforms[mesh.ParentBone.Index] * world2;
                    BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                    model2Spheres[i] = transSphere;
                    if (object2.physicLayer != Layer.DispenserTrigger)
                        model2Spheres[i].Radius = 0.1f;
                }

                bool collision = false;

                for (int i = 0; i < model1Spheres.Length; i++)
                    for (int j = 0; j < model2Spheres.Length; j++)
                        if (model1Spheres[i].Intersects(model2Spheres[j]))
                        {
                            //Debug.WriteLine("Precise collision");
                            return true;
                            //collision = true;
                        }

                if (collision)
                {
                    //Debug.WriteLine("Precise collision");
                }
                else
                {
                    if (object2.GetComponent<Collider>().IsTrigger)
                    {
                        if (object2.GetComponent<Collider>().OnTriggerEnter)
                        {
                            object2.GetComponent<Collider>().OnTriggerExit = true;
                            object2.OnTriggerExit(object1);
                            object2.GetComponent<Collider>().OnTriggerEnter = false;
                            object2.GetComponent<Collider>().OnTriggerExit = false;
                        }
                    }

                    if (object1.GetComponent<Collider>().IsTrigger)
                    {
                        if (object1.GetComponent<Collider>().OnTriggerEnter)
                        {
                            object1.GetComponent<Collider>().OnTriggerExit = true;
                            object1.OnTriggerExit(object1);
                            object1.GetComponent<Collider>().OnTriggerEnter = false;
                            object1.GetComponent<Collider>().OnTriggerExit = false;
                        }
                    }

                    //if (object1.GetComponent<Collider>().OnCollisionEnter)
                    //{
                    //    object1.GetComponent<Collider>().OnCollisionExit = true;
                    //    object1.OnCollisionExit(object2);
                    //    object1.GetComponent<Collider>().OnCollisionEnter = false;
                    //    object1.GetComponent<Collider>().OnCollisionExit = false;
                    //}
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
                            //Debug.WriteLine("Precise collision");
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

                Matrix[] model1Transforms = new Matrix[object1.GetComponent<Renderer>().getModel().Bones.Count];
                object1.GetComponent<Renderer>().getModel().CopyAbsoluteBoneTransformsTo(model1Transforms);
                BoundingSphere[] model1Spheres = new BoundingSphere[object1.GetComponent<Renderer>().getModel().Meshes.Count];
                for (int i = 0; i < object1.GetComponent<Renderer>().getModel().Meshes.Count; i++)
                {
                    ModelMesh mesh = object1.GetComponent<Renderer>().getModel().Meshes[i];
                    BoundingSphere origSphere = mesh.BoundingSphere;
                    Matrix trans = model1Transforms[mesh.ParentBone.Index] * world1;
                    BoundingSphere transSphere = Collider.TransformBoundingSphere(origSphere, trans);
                    model1Spheres[i] = transSphere;
                    model1Spheres[i].Radius = 0.01f;
                }

                BoundingBox[] object2Colliders = object2.GetComponent<BoxCollider>().GetPreciseBoundingBoxes();

                BoundingSphere origSphere1 = object1.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
                BoundingSphere sphere1 = Collider.TransformBoundingSphere(origSphere1, world1);
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
                        if (model1Spheres[i].Intersects(object2Colliders[j]) || sphere1.Intersects(object2Colliders[j]))
                        {
                            //Debug.WriteLine("sphere collision");
                            if(object1.physicLayer == Layer.Player)
                            {
                                object1.collision = true;
                            }
                            return true;
                        }

                if (collision)
                {
                    //Debug.WriteLine("Precise collision");
                }
                else
                {
                    if (object2.GetComponent<Collider>().IsTrigger)
                    {
                        if (object2.GetComponent<Collider>().OnTriggerEnter)
                        {
                            object2.GetComponent<Collider>().OnTriggerExit = true;
                            object2.OnTriggerExit(object1);
                            object2.GetComponent<Collider>().OnTriggerEnter = false;
                            object2.GetComponent<Collider>().OnTriggerExit = false;
                        }
                    }

                    //if (object1.GetComponent<Collider>().OnCollisionEnter)
                    //{
                    //    object1.GetComponent<Collider>().OnCollisionExit = true;
                    //    object1.OnCollisionExit(object2);
                    //    object1.GetComponent<Collider>().OnCollisionEnter = false;
                    //    object1.GetComponent<Collider>().OnCollisionExit = false;
                    //}
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
