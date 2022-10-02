using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;

        private void Awake()
        {
            _source.PlayOneShot(_clip);
        }
    }
}