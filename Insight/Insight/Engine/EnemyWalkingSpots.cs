using Insight.Engine.Components;
using Insight.Materials;
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
    public class PathNode
    {
        public List<PathNode> neighbours;
        public Vector3 rootPoint;
        public int nodeID;
        public PathNode(Vector3 root, int id)
        {
            nodeID = id;
            rootPoint = root;
            neighbours = new List<PathNode>();
        }
        public PathNode()
        {
        }

        public void addNeighbour(PathNode node)
        {
            neighbours.Add(node);
        }
    }
    public class EnemyWalkingSpots
    {

        public List<GameObject> sceneNodes = new List<GameObject>();
        private static EnemyWalkingSpots instance = null;
        public static EnemyWalkingSpots getInstance()
        {
            if (instance == null)
                instance = new EnemyWalkingSpots();
            return instance;
        }
        static public List<PathNode> nodes;

        PathNode pathPoint1;
        PathNode pathPoint2;
        PathNode pathPoint3;
        PathNode pathPoint4;
        PathNode pathPoint5;
        PathNode pathPoint6;
        PathNode pathPoint7;
        PathNode pathPoint8;
        PathNode pathPoint9;
        PathNode pathPoint10;
        PathNode pathPoint11;
        PathNode pathPoint12;
        PathNode pathPoint13;
        PathNode pathPoint14;
        PathNode pathPoint15;
        PathNode pathPoint16;
        PathNode pathPoint17;
        PathNode pathPoint18;
        PathNode pathPoint19;
        PathNode pathPoint20;
        PathNode pathPoint21;
        PathNode pathPoint22;
        PathNode pathPoint23;
        PathNode pathPoint24;
        PathNode pathPoint25;
        PathNode pathPoint26;
        PathNode pathPoint27;
        PathNode pathPoint28;
        PathNode pathPoint29;

        public EnemyWalkingSpots()
        {
            nodes = new List<PathNode>();
            pathPoint1 = new PathNode(new Vector3(2.5f, 0, 0), 1);
            pathPoint2 = new PathNode(new Vector3(2.5f, 0, 5), 2);
            pathPoint3 = new PathNode(new Vector3(2.5f, 0, 9.5f), 3);
            pathPoint4 = new PathNode(new Vector3(3, 0, 11.5f), 4);
            pathPoint5 = new PathNode(new Vector3(5.5f, 0, 13f), 5);
            pathPoint6 = new PathNode(new Vector3(10, 0, 13.5f), 6);
            pathPoint7 = new PathNode(new Vector3(18.5f, 0, 13.5f), 7);
            pathPoint8 = new PathNode(new Vector3(18.5f, 0, 6), 8);
            pathPoint9 = new PathNode(new Vector3(18.5f, 0, 3.5f), 9);
            pathPoint10 = new PathNode(new Vector3(25, 0, 13.5f), 10);
            pathPoint11 = new PathNode(new Vector3(30, 0, 13.5f), 11);
            pathPoint12 = new PathNode(new Vector3(33.5f, 0, 14.5f), 12);
            pathPoint13 = new PathNode(new Vector3(34, 0, 16.5f), 13);
            pathPoint14 = new PathNode(new Vector3(34, 0, 20), 14);

            pathPoint15 = new PathNode(new Vector3(3.5f, 0, 12.5f), 15);
            pathPoint16 = new PathNode(new Vector3(4.5f, 0, 13), 16);
            pathPoint17 = new PathNode(new Vector3(8.0f, 0, 12.5f), 17);
            pathPoint18 = new PathNode(new Vector3(13, 0, 13.5f), 18);
            pathPoint19 = new PathNode(new Vector3(17f, 0, 13.5f), 19);
            pathPoint20 = new PathNode(new Vector3(21, 0, 13.5f), 20);
            pathPoint21 = new PathNode(new Vector3(18.5f, 0, 12.5f), 21);
            pathPoint22 = new PathNode(new Vector3(18.5f, 0, 11f), 22);
            pathPoint23 = new PathNode(new Vector3(18.5f, 0, 8.5f), 23);
            pathPoint24 = new PathNode(new Vector3(2.5f, 0, 7.5f), 24);
            pathPoint25 = new PathNode(new Vector3(2.5f, 0, 2.5f), 25);
            pathPoint26 = new PathNode(new Vector3(16f, 0, 13.5f), 26);
            pathPoint27 = new PathNode(new Vector3(23, 0, 13.5f), 27);
            pathPoint28 = new PathNode(new Vector3(28, 0, 13.5f), 28);
            pathPoint29 = new PathNode(new Vector3(32, 0, 14), 29);

            nodes.Add(pathPoint1);
            nodes.Add(pathPoint2);
            nodes.Add(pathPoint3);
            nodes.Add(pathPoint4);
            nodes.Add(pathPoint5);
            nodes.Add(pathPoint6);
            nodes.Add(pathPoint7);
            nodes.Add(pathPoint8);
            nodes.Add(pathPoint9);
            nodes.Add(pathPoint10);
            nodes.Add(pathPoint11);
            nodes.Add(pathPoint12);
            nodes.Add(pathPoint13);
            nodes.Add(pathPoint14);

            nodes.Add(pathPoint15);
            nodes.Add(pathPoint16);
            nodes.Add(pathPoint17);
            nodes.Add(pathPoint18);
            nodes.Add(pathPoint19);
            nodes.Add(pathPoint20);
            nodes.Add(pathPoint21);
            nodes.Add(pathPoint22);
            nodes.Add(pathPoint23);
            nodes.Add(pathPoint24);
            nodes.Add(pathPoint25);
            nodes.Add(pathPoint26);
            nodes.Add(pathPoint27);
            nodes.Add(pathPoint28);
            nodes.Add(pathPoint29);

            AddNeighbourToNode(1, 25);
            AddNeighbourToNode(25, 1);
            AddNeighbourToNode(25, 2);
            AddNeighbourToNode(2, 25);
            AddNeighbourToNode(2, 22);
            AddNeighbourToNode(24, 3);
            AddNeighbourToNode(24, 2);
            AddNeighbourToNode(3, 24);
            AddNeighbourToNode(3, 4);
            AddNeighbourToNode(4, 15);
            AddNeighbourToNode(4, 3);
            AddNeighbourToNode(15, 16);
            AddNeighbourToNode(15, 4);
            AddNeighbourToNode(16, 5);
            AddNeighbourToNode(16, 15);
            AddNeighbourToNode(5, 17);
            AddNeighbourToNode(5, 16);
            AddNeighbourToNode(17, 5);
            AddNeighbourToNode(17, 6);
            AddNeighbourToNode(6, 18);
            AddNeighbourToNode(6, 17);
            AddNeighbourToNode(18, 26);
            AddNeighbourToNode(18, 6);
            AddNeighbourToNode(26, 19);
            AddNeighbourToNode(26, 18);
            AddNeighbourToNode(19, 7);
            AddNeighbourToNode(19, 26);
            AddNeighbourToNode(7, 19);
            AddNeighbourToNode(7, 21);
            AddNeighbourToNode(7, 20);

            AddNeighbourToNode(21, 7);
            AddNeighbourToNode(21, 22);
            AddNeighbourToNode(22, 21);
            AddNeighbourToNode(22, 23);
            AddNeighbourToNode(23, 22);
            AddNeighbourToNode(23, 8);
            AddNeighbourToNode(8, 23);
            AddNeighbourToNode(8, 9);
            AddNeighbourToNode(9, 8);

            AddNeighbourToNode(20, 7);
            AddNeighbourToNode(20, 27);
            AddNeighbourToNode(27, 20);
            AddNeighbourToNode(27, 10);
            AddNeighbourToNode(10, 27);
            AddNeighbourToNode(10, 28);
            AddNeighbourToNode(28, 11);
            AddNeighbourToNode(28, 10);
            AddNeighbourToNode(11, 28);
            AddNeighbourToNode(11, 29);
            AddNeighbourToNode(29, 11);
            AddNeighbourToNode(29, 12);
            AddNeighbourToNode(12, 29);
            AddNeighbourToNode(12, 13);
            AddNeighbourToNode(13, 12);
            AddNeighbourToNode(13, 14);
            AddNeighbourToNode(14, 13);


            sceneNodes = SpawnNodesOnMap();


        }

        public Vector3 findNearestPathToPlayer(Vector3 currentPosition, List<int> visitedPath)
        {
            PathNode enemyNearbyNode = findNearestNode(currentPosition);
            Vector3 playerPosition = SceneManager.Instance.currentScene.player.Transform.Position;

            float distance = 9999.0f;
            PathNode destNode = new PathNode();
            foreach (PathNode node in enemyNearbyNode.neighbours)
            {
                float tmpDist = Vector3.Distance(node.rootPoint, playerPosition);
                if (tmpDist < distance)
                {
                    distance = tmpDist;
                    destNode = node;
                }
            }
            return destNode.rootPoint;
        }

        public Vector3 findNearestPath(Vector3 currentPosition, Vector3 destPath)
        {
            PathNode enemyNearbyNode = findNearestNode(currentPosition);

            float distance = 9999.0f;
            PathNode destNode = new PathNode();
            foreach (PathNode node in enemyNearbyNode.neighbours)
            {
                float tmpDist = Vector3.Distance(node.rootPoint, destPath);
                if (tmpDist < distance)
                {
                    distance = tmpDist;
                    destNode = node;
                }
            }
            return destNode.rootPoint;
        }

        public PathNode findNearestNode(Vector3 pos)
        {
            float distance = 9999.0f;
            PathNode nearestNode = new PathNode();
            foreach (PathNode node in nodes)
            {
                float tmpDist = Vector3.Distance(node.rootPoint, pos);
                if (tmpDist < distance)
                {
                    distance = tmpDist;
                    nearestNode = node;
                }
            }
            return nearestNode;
        }

        [System.Obsolete("MoveToDestination is deprecated, please use MoveGameObjectToDestination instead.")]
        public Vector3 MoveToDestination(Vector3 currentPosition, Vector3 targetDestination, float speed)
        {
            Vector3 nearest = currentPosition;
            if (Vector3.Distance(nearest, currentPosition) <= 0.1f)
                nearest = findNearestPath(currentPosition, targetDestination);
            if (Vector3.Distance(nearest, currentPosition) > 0.1f)
                return VectorHelper.MoveTowards(currentPosition, nearest, speed);

            return currentPosition;
        }

        public void MoveGameObjectToDestination(GameObject gObject, Vector3 targetDestination, float speed, float stopValue)
        {
            Vector3 nearest = gObject.Transform.Position;
            Vector3 direction = new Vector3();
            float angle = 0;
            if (Vector3.Distance(gObject.Transform.Position, targetDestination) <= stopValue)
            {
                //Face player
                direction = SceneManager.Instance.currentScene.player.Transform.Position - gObject.Transform.Position;
                angle = (float)(Math.Atan2(direction.X, direction.Z));
                gObject.Transform.Rotation.Y = angle;
                return;
            }

            if (Vector3.Distance(nearest, gObject.Transform.Position) <= 0.1f)
                nearest = findNearestPath(gObject.Transform.Position, targetDestination);
            if (Vector3.Distance(nearest, gObject.Transform.Position) > 0.1f)
            {
                direction = nearest - gObject.Transform.Position;
                angle = (float)(Math.Atan2(direction.X, direction.Z));
                gObject.Transform.Position = VectorHelper.MoveTowards(gObject.Transform.Position, nearest, speed);
             }
            gObject.Transform.Rotation.Y = angle;

        }

        public float DistanceFromDestination(Vector3 currentPosition, Vector3 targetDestination)
        {
            PathNode nearestNodeFromCurrent = findNearestNode(currentPosition);
            PathNode nearestNodeFromDestination = findNearestNode(targetDestination);
            PathNode currentNode = nearestNodeFromCurrent;
            int maxNodes = 0;
            float distance = 0.0f;
            while(currentNode.nodeID != nearestNodeFromDestination.nodeID)
            {
                PathNode nearest = new PathNode();
                float dist = 9999.0f;
                foreach (PathNode node in currentNode.neighbours)
                {
                    if(Vector3.Distance(node.rootPoint, targetDestination) < dist)
                    {
                        dist = Vector3.Distance(node.rootPoint, targetDestination);
                        nearest = node;
                    }
                }
                distance += Vector3.Distance(currentNode.rootPoint, nearest.rootPoint);
                currentNode = nearest;
                maxNodes++;

                if (maxNodes > 15)
                    return 9999.0f;
            }
            return distance;
        }

        public List<GameObject> SpawnNodesOnMap()
        {
            List<GameObject> nodeObjects = new List<GameObject>();
            foreach (PathNode node in nodes)
            {
                nodeObjects.Add(new GameObject(node.rootPoint, false));
            }

            foreach (GameObject go in nodeObjects)
            {
                
                go.AddNewComponent<MeshRenderer>();
                Effect e = SceneManager.Instance.Content.Load<Effect>("Shaders/PhongBlinnShader");
                go.GetComponent<MeshRenderer>().Material = new DefaultMaterial(e);
                go.GetComponent<MeshRenderer>().Load(ContentModels.Instance.ball, 0.05f);
                go.Transform.Position.Y += 1.5f;
            }

            return nodeObjects;
        }

        public void Draw()
        {
            foreach (GameObject item in sceneNodes)
            {
                item.Draw(SceneManager.Instance.currentScene.GetMainCamera());
            }
        }

        void AddNeighbourToNode(int nodeID, int neighbour)
        {
            nodes[nodeID -1].addNeighbour(nodes[neighbour - 1]);
        }

    }
}
