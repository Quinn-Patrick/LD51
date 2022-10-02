using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] protected AudioSource _source;
        [SerializeField] protected Transform _pseudoParent;
        protected AudioListener _listener;
        protected void Awake()
        {
            _listener = FindObjectOfType<AudioListener>();
        }
        public void PlaySoundWithVolume(AudioClip _clip, float volume)
        {
            if (volume > 1) volume = 1;
            if (_source == null)
            {
                _source = GetComponent<AudioSource>();
            }
            _source.PlayOneShot(_clip, ComputeVolume() * volume);
        }

        protected float ComputeVolume()
        {
            if (_listener == null) return 1f;
            float distance = Vector3.Distance(_source.transform.position, _listener.transform.position - new Vector3(0, 0, -14)) / 4;
            if (distance < float.Epsilon) return 1f;

            float effectiveVolume = 4 / (distance * distance);
            if (effectiveVolume > 1) return 1f;
            else return effectiveVolume;
        }
    }
}