using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class TitleScreenText : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _player;
        [SerializeField] private AudioClip _clip;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _player.PlaySoundWithVolume(_clip, collision.relativeVelocity.magnitude / 1);
        }
    }
}