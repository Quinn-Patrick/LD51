using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class GlobalCharacteristics : MonoBehaviour
    {
        public static GlobalCharacteristics Instance;
        [SerializeField]private float _gravity;
        public float CameraShake { get; set; }
        public float CameraShakeTimer { get; set; }
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

        private void Update()
        {
            CameraShakeTimer -= Time.deltaTime;
        }

        public float GetGravity()
        {
            return _gravity;
        }
    }
}