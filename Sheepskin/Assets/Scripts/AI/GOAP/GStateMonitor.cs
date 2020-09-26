using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goap
{
    public class GStateMonitor : MonoBehaviour
    {

        public string state;
        public WorldStates beliefs;
        public GameObject resPrefab;
        public string queueName;
        public string worldState;
        public GAction action;


        bool stateFound = false;
        bool isPlaced = false;
        [SerializeField]
        float timeToInstant = 5f;

        private void Awake() 
        {
            beliefs = GetComponent<GAgent>().beliefs;
            //initStrength = stateStrength;
        }

        void LateUpdate()
        {

            if(action.running && beliefs.HasState(state))
            {
                stateFound = true;
            }
            else
            {
                isPlaced = false;
            }

            if(stateFound)
            {
                bool isPuddleTime = Random.Range(1,50) == 1;
                if(isPuddleTime)
                {
                    // Vector3 loc = new Vector3(transform.position.x,
                    //     resPrefab.transform.position.y,transform.transform.position.z);
                    // GameObject clone = Instantiate(resPrefab,loc,resPrefab.transform.rotation);
                    if(!isPlaced)
                    {
                        Invoke("InstantRes",timeToInstant);
                        isPlaced = true;
                    }
                    stateFound = false;
                    
                }
            }
        }

        void InstantRes()
        {
            Vector3 loc = new Vector3(transform.position.x,
                        resPrefab.transform.position.y, transform.transform.position.z);
            GameObject clone = Instantiate(resPrefab, loc, resPrefab.transform.rotation);

            GWorld.Instance.GetQueue(queueName).AddResource(clone);
            GWorld.Instance.GetWorld().ModifyState(worldState, 1);
        }
    }
}