using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class ParticleExplosion : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        private float _timer = 0;

        private void OnEnable()
        {
            _timer = 5f;
            _particleSystem.Play();
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}