﻿using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class EnemyManager : MonoBehaviour
    {
        public List<EnemyController> Enemies { get; private set; }
        public int NumberOfEnemiesTotal { get; private set; }
        public int NumberOfEnemiesRemaining => Enemies.Count;
        private static EnemyManager instance;

        public static EnemyManager GetInstance() => instance;

        void Awake()
        {
            instance = this;
            Enemies = new List<EnemyController>();
        }

        public void RegisterEnemy(EnemyController enemy)
        {
            Enemies.Add(enemy);

            NumberOfEnemiesTotal++;
        }

        public void UnregisterEnemy(EnemyController enemyKilled)
        {
            int enemiesRemainingNotification = NumberOfEnemiesRemaining - 1;
            //enemyKilled.SpawnSection.OnEnemyInSectionKill(enemyKilled.transform);

            // removes the enemy from the list, so that we can keep track of how many are left on the map
            Enemies.Remove(enemyKilled);
        }

        private void OnDestroy()
        {

        }
    }
}