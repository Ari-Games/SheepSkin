using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goap
{
    [ExecuteInEditMode]
    public class GAgentVisual : MonoBehaviour
    {
        public GAgent thisAgent;
        [SerializeField] List<string> beliefStateKey;
        [SerializeField] List<int> beliefStateValue;
        // Start is called before the first frame update
        void Start()
        {
            thisAgent = this.GetComponent<GAgent>();
        }

        private void Update() 
        {
            beliefStateKey = new List<string>(thisAgent.beliefs.states.Keys);
            beliefStateValue = new List<int>(thisAgent.beliefs.states.Values);
        }
    }
}