using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class ParticleExplosion : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private AudioClip _clip;
        private bool _ready = false;
        private float _timer = 0;

        private void OnEnable()
        {
            if(_ready)_soundPlayer.PlaySoundWithVolume(_clip, 1.0f);
            _ready = true;
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