using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level
{
    [CreateAssetMenu(fileName = "Task", menuName = "LevelTaskKillSheep", order = 51)]
    public class TaskKillSheep : Task
    {
        [SerializeField] private int countKills;
        [SerializeField] private int requiredKills;
        public TaskKillSheep(string description, int requiredKills) : base(description)
        {
            this.countKills = 0;
            this.requiredKills = requiredKills;
        }

        public override bool IsCompleted()
        {
            return countKills >= requiredKills;
        }

        public void IncKills() => countKills++;

        public override string ToString()
        {
            return $"{ base.ToString()} {countKills}  {requiredKills}";
        }
    }
}
