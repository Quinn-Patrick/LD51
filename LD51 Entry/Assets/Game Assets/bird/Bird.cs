using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Bird : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private SoundPlayer _player;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private Animator _anim;
        private bool _active = false;
        private void FixedUpdate()
        {
            if (_active) return;
            if(Tower.GetTowerHeight() > 17f)
            {
                _body.velocity = new Vector2(5f, 0f);
                _active = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _body.gravityScale = 1f;
            _player.PlaySoundWithVolume(_clip, collision.relativeVelocity.magnitude / 2);
            _anim.SetBool("isDead", true);
        }
    }
}