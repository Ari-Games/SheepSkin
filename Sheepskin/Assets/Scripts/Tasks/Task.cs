using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tasks
{
    [CreateAssetMenu(fileName = "Task", menuName = "Task", order = 51)]
    public class Task : ScriptableObject
    {
        [SerializeField] private string description;
        [SerializeField] private int requiredCountSheep;

        public bool IsComplete()
        {
            if (Player.Player.Instance.CountOfSheepEaten == requiredCountSheep)
                return true;
            return false;
        }

        public int Progress()
        {
            return requiredCountSheep - Player.Player.Instance.CountOfSheepEaten;
        }
    }
}
