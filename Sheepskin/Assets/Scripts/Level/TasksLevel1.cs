using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Level
{
    public class TasksLevel1 : MonoBehaviour
    {
        [SerializeField] public List<Task> tasks;

        private void Start()
        {
            foreach (var task in tasks)
                Debug.Log(task);
        }
    }
}