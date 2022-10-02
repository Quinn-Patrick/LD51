using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class BlockGenerator : MonoBehaviour
    {
        public static BlockGenerator Instance;
        [SerializeField] private BlockPool _blockPool;
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
            if (!GameTimer.GameActive)
            {
                _spawnActivated = false;
                return;
            }
            _timeUntilSpawn -= Time.deltaTime;
            if(_timeUntilSpawn < 0f && _spawnActivated)
            {
                if(Physics2D.OverlapCircle(new Vector2(0f, Tower.GetTowerHeight() + 10f), 2.5f) != null)
                {
                    return;
                }
                _spawnActivated = false;
                GameObject newBlock = _blockPool.GetObject();
                newBlock.transform.position = new Vector2(0f, Tower.GetTowerHeight() + 10f);
            }
        }
    }
}