using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class SnakeGenerator : MonoBehaviour
    {
        [SerializeField] private BlockPool _snakePool;
        public static SnakeGenerator Instance;
        private void Awake()
        {
            Instance = this;
        }

        public void SpawnSnake()
        {
            _snakePool.GetObject();
        }
    }
}