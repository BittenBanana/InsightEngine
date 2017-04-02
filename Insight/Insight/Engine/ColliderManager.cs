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
        Vector3[] lastModelPosition;

        public ColliderManager(List<GameObject> gameObjects)
        {           
            isCollision = false;
            lastModelPosition = new Vector3[MainScene.GetGameObjects().Count];
        }

        public void Update()
        {
            int i = 0;
            foreach(GameObject gameObject in MainScene.GetGameObjects())
            {
                lastModelPosition[i] = gameObject.Transform.Position;
                i++;
            }
            
            for(int j = 0; j < MainScene.GetGameObjects().Count; j++)
            {
                for(int k = j; k < MainScene.GetGameObjects().Count; k++)
                {
                    if(MainScene.GetGameObjects()[j] != MainScene.GetGameObjects()[k])
                    isCollision = PreciseCollisionTest(MainScene.GetGameObjects()[j], MainScene.GetGameObjects()[j].GetComponent<MeshRenderer>().GetMatrix(),
                    MainScene.GetGameObjects()[k], MainScene.GetGameObjects()[k].GetComponent<MeshRenderer>().GetMatrix());
                }
            }
        }

        private bool OverallCollisionTest(GameObject object1, Matrix world1, GameObject object2, Matrix world2)
        {
            BoundingSphere origSphere1 = object1.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
            
            BoundingSphere sphere1 = SphereCollider.TransformBoundingSphere(origSphere1, world1);

            BoundingSphere origSphere2 = object2.GetComponent<SphereCollider>().GetCompleteBoundingSphere();
            BoundingSphere sphere2 = SphereCollider.TransformBoundingSphere(origSphere2, world2);

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

        private bool PreciseCollisionTest(GameObject object1, Matrix world1, GameObject object2, Matrix world2)
        {
            if (OverallCollisionTest(object1, world1, object2, world2) == false)
                return false;

            BoundingSphere[] object1Spheres = object1.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();
            BoundingSphere[] object2Spheres = object2.GetComponent<SphereCollider>().GetPreciseBoundingSpheres();


            bool collision = false;

            for (int i = 0; i < object1Spheres.Length; i++)
                for (int j = 0; j < object2Spheres.Length; j++)
                    if (object1Spheres[i].Intersects(object2Spheres[j]))
                    {
                        Debug.WriteLine("Precise collision");
                        return true;                       
                    }
                        

            return collision;

        }
    }
}
