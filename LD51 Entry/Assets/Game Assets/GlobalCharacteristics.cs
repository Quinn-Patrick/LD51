using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class GlobalCharacteristics : MonoBehaviour
    {
        public static GlobalCharacteristics Instance;
        [SerializeField]private float _gravity;
        private void Awake()
        {
            Instance = this;
        }

        public void IncreaseGravity(float factor)
        {
            _gravity += factor;
            if(_gravity < 0)
            {
                _gravity -= factor;
            }
        }

        public float GetGravity()
        {
            return _gravity;
        }
    }
}