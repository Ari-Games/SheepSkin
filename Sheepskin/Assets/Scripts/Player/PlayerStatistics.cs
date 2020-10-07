using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerStatistics
    {
        public int CurrentLevel { get; set; }
        public int OpenedLevels { get; set; }
    }

    public class PlayerStateOnLevel
    {
        public bool IsLife { get; set; }
        public int CountOfSheepEaten { get; set; }
        public Vector3 LastPosition { get; set; }
    }
}
