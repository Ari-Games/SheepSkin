using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public sealed class Player
    {
        private static readonly Player instance = new Player();

        private const string pathToSaveFileAllStats = "AllStats.dat";
        private const string pathToSaveFileLocalStats = "localStats.dat";
        private int currentLevel;
        private int openedLevel;

        public bool IsLife { get; set; }
        public int CountOfSheepEaten { get; set; }
        private Player()
        {
            LoadGlobalStats();
        }

        public static Player Instance
        {

            get { return instance; }
        }

        public void NewGame()
        {
            IsLife = true;
            CountOfSheepEaten = 0;
        }

        public void EatSheep() => CountOfSheepEaten++;

        public void SaveGlobalStats()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
    + pathToSaveFileAllStats);
            PlayerStatistics stats = new PlayerStatistics();
            stats.CurrentLevel = currentLevel;
            stats.OpenedLevels = openedLevel;
            bf.Serialize(file, stats);
            file.Close();
        }

        public void LoadGlobalStats()
        {
            if (File.Exists(Application.persistentDataPath
    + pathToSaveFileAllStats))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                  File.Open(Application.persistentDataPath
                  + pathToSaveFileAllStats, FileMode.Open);
                PlayerStatistics stats = (PlayerStatistics)bf.Deserialize(file);
                file.Close();
                currentLevel = stats.CurrentLevel;
                openedLevel = stats.OpenedLevels;
            }
        }

        public void SaveLocalStats(Vector3 position)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
    + pathToSaveFileAllStats);
            PlayerStateOnLevel stats = new PlayerStateOnLevel();
            stats.CountOfSheepEaten = CountOfSheepEaten;
            stats.IsLife = IsLife;
            stats.LastPosition = position;
            
            bf.Serialize(file, stats);
            file.Close();
        }

        public Vector3 LoadLocalStats()
        {
            if (File.Exists(Application.persistentDataPath
    + pathToSaveFileAllStats))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                  File.Open(Application.persistentDataPath
                  + pathToSaveFileAllStats, FileMode.Open);
                PlayerStateOnLevel stats = (PlayerStateOnLevel)bf.Deserialize(file);
                file.Close();
                CountOfSheepEaten = stats.CountOfSheepEaten;
                IsLife = stats.IsLife;
                return stats.LastPosition;
            }
            return Vector3.zero;
        }
    }
}
