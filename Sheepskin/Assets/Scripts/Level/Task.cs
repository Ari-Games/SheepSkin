using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level
{
    [CreateAssetMenu(fileName = "New Task", menuName = "LevelTask", order = 51)]
    public class Task : ScriptableObject
    {
        [SerializeField] public string Description;
        [SerializeField] protected bool isComplete;

        
        public Task(string description)
        {
            Description = description;
            isComplete = false;
        }

        public virtual bool IsCompleted()
        {
            return isComplete;
        }

        public override string ToString()
        {
            return $"{Description} {isComplete}";
        }
    }
}
