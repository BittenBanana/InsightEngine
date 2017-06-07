using Microsoft.Xna.Framework;
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

        public EnemyWalkingSpots()
        {
            nodes = new List<PathNode>();
            pathPoint1 = new PathNode(new Vector3(2.5f, 0, 0), 1);
            pathPoint2 = new PathNode(new Vector3(2.5f, 0, 5), 2);
            pathPoint3 = new PathNode(new Vector3(2.5f, 0, 9.5f), 3);
            pathPoint4 = new PathNode(new Vector3(3, 0, 11.5f), 4);
            pathPoint5 = new PathNode(new Vector3(5.5f, 0, 13.5f), 5);
            pathPoint6 = new PathNode(new Vector3(10, 0, 13.5f), 6);
            pathPoint7 = new PathNode(new Vector3(17.5f, 0, 13.5f), 7);
            pathPoint8 = new PathNode(new Vector3(17.5f, 0, 6), 8);
            pathPoint9 = new PathNode(new Vector3(17.5f, 0, 3.5f), 9);
            pathPoint10 = new PathNode(new Vector3(25, 0, 13.5f), 10);
            pathPoint11 = new PathNode(new Vector3(30, 0, 13.5f), 11);
            pathPoint12 = new PathNode(new Vector3(33.5f, 0, 14.5f), 12);
            pathPoint13 = new PathNode(new Vector3(34, 0, 16.5f), 13);
            pathPoint14 = new PathNode(new Vector3(34, 0, 20), 14);

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

            pathPoint1.addNeighbour(pathPoint2);

            pathPoint2.addNeighbour(pathPoint1);
            pathPoint2.addNeighbour(pathPoint3);

            pathPoint3.addNeighbour(pathPoint2);
            pathPoint3.addNeighbour(pathPoint4);

            pathPoint4.addNeighbour(pathPoint3);
            pathPoint4.addNeighbour(pathPoint5);

            pathPoint5.addNeighbour(pathPoint4);
            pathPoint5.addNeighbour(pathPoint6);

            pathPoint6.addNeighbour(pathPoint5);
            pathPoint6.addNeighbour(pathPoint7);

            pathPoint7.addNeighbour(pathPoint6);
            pathPoint7.addNeighbour(pathPoint8);
            pathPoint7.addNeighbour(pathPoint10);

            pathPoint8.addNeighbour(pathPoint9);
            pathPoint8.addNeighbour(pathPoint7);

            pathPoint9.addNeighbour(pathPoint8);

            pathPoint10.addNeighbour(pathPoint7);
            pathPoint10.addNeighbour(pathPoint11);

            pathPoint11.addNeighbour(pathPoint10);
            pathPoint11.addNeighbour(pathPoint12);

            pathPoint12.addNeighbour(pathPoint11);
            pathPoint12.addNeighbour(pathPoint13);

            pathPoint13.addNeighbour(pathPoint12);
            pathPoint13.addNeighbour(pathPoint14);

            pathPoint14.addNeighbour(pathPoint13);
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
            Debug.WriteLine(destNode.nodeID);
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
            Debug.WriteLine(destNode.nodeID);
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
            if (Vector3.Distance(gObject.Transform.Position, targetDestination) <= stopValue)
                return;
            if (Vector3.Distance(nearest, gObject.Transform.Position) <= 0.1f)
                nearest = findNearestPath(gObject.Transform.Position, targetDestination);
            if (Vector3.Distance(nearest, gObject.Transform.Position) > 0.1f)
                gObject.Transform.Position = VectorHelper.MoveTowards(gObject.Transform.Position, nearest, speed);
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
    }
}
