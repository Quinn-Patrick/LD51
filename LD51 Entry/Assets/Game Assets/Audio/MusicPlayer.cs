using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioClip _clip8Bit;
        [SerializeField] private AudioClip _clipMetal;

        private void Awake()
        {
            if(BonusModes.Instance == null)
            {
                _source.PlayOneShot(_clip);
                return;
            }
            if (BonusModes.Instance.musicMode == 0)
            {
                _source.PlayOneShot(_clip);
            }
            else if (BonusModes.Instance.musicMode == 1)
            {
                _source.PlayOneShot(_clip8Bit);
            }
            else if (BonusModes.Instance.musicMode == 2)
            {
                _source.PlayOneShot(_clipMetal);
            }
        }
    }
}