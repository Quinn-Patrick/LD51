using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class BlockGenerator : MonoBehaviour
    {
        private float timer;
        public static BlockGenerator Instance;
        private float _timeUntilSpawn;
        private bool _spawnActivated;
        private void Awake()
        {
            Instance = this;
            StartSpawnTimer();
        }
        public void StartSpawnTimer()
        {
            _timeUntilSpawn = 1.0f;
            _spawnActivated = true;
        }

        private void Update()
        {
            _timeUntilSpawn -= Time.deltaTime;
            if(_timeUntilSpawn < 0f && _spawnActivated)
            {
                _spawnActivated = false;
                GameObject newBlock = BlockPool.GetObject();
                newBlock.transform.position = new Vector2(0f, Tower.GetTowerHeight() + 10f);
            }
        }
    }
}