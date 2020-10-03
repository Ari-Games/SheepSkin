using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Goap
{
    public class ResourceQueue
    {
        public Queue<GameObject> que = new Queue<GameObject>();
        public string tag;
        public string modState;

        public ResourceQueue(string tag, string modState, WorldStates wStates)
        {
            this.tag = tag;
            this.modState = modState;
            if(tag != "")
            {
                GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
                foreach(var res in resources)
                {
                    que.Enqueue(res);
                }
            }

            if(modState != "")
            {
                wStates.ModifyState(modState, que.Count);
            }
        }

        public void AddResource(GameObject res)
        {
            que.Enqueue(res);
        }

        public GameObject RemoveResource()
        {
            if(que.Count == 0)
            {
                return null;
            }
            return que.Dequeue();
        }

        public void RemoveForDragging(GameObject item)
        {
            que = new Queue<GameObject>(que.Where(x => x != item));
        }
    }

    public sealed class GWorld {

        // Our GWorld instance
        private static readonly GWorld instance = new GWorld();
        // Our world states
        private static WorldStates world;
        // Queue of patients
        private static ResourceQueue flowers;
        private static ResourceQueue restPoints;
        private static ResourceQueue patrolPaths;
        private static ResourceQueue bloodSteps;

        private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();
        private static Vector2 lastWolfPosition = new Vector2(0,0);

        static GWorld() 
        {
            // Create our world
            world = new WorldStates();
            flowers = new ResourceQueue("","",world); 
            resources.Add("flowers",flowers);

            restPoints = new ResourceQueue("", "", world);
            resources.Add("restPoints", restPoints);
            
            patrolPaths = new ResourceQueue("Path", "FreePath", world);
            resources.Add("patrolPaths", patrolPaths);

            bloodSteps = new ResourceQueue("", "",world);
            resources.Add("bloodSteps", bloodSteps);
        }

        public ResourceQueue GetQueue(string type)
        {
            return resources[type];
        }
        private GWorld() 
        {

        }

        public Vector2 GetLastWolfPosition()
        {
            return lastWolfPosition;
        }

        public void SetLastWolfPosition(Vector2 wolfPosition)
        {
            lastWolfPosition = wolfPosition;
        }

        public static GWorld Instance {

            get { return instance; }
        }

        public WorldStates GetWorld() {

            return world;
        }
    }
}