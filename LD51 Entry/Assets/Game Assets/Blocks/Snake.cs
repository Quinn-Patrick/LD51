using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private AudioClip _plopSound;
        private float _invisibilityTimer = 5f;
        private SpriteRenderer _spriteRenderer;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if(_spriteRenderer == null)
            {
                _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            }
            if(_spriteRenderer == null)
            {
                _spriteRenderer = transform.GetChild(0).GetChild(0).
                GetComponent<SpriteRenderer>();
            }
        }
        private void OnEnable()
        {
            _body.transform.position = new Vector2(0f, Tower.GetTowerHeight() + 15f);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _soundPlayer.PlaySoundWithVolume(_plopSound, collision.relativeVelocity.magnitude / 2);
        }
        private void FixedUpdate()
        {
            if (_spriteRenderer == null) return;
            if (!_spriteRenderer.enabled)
            {
                _invisibilityTimer -= Time.fixedDeltaTime;
                if (_invisibilityTimer < 0)
                {
                    _spriteRenderer.enabled = true;
                    _invisibilityTimer = 5f;
                }
            }
        }
    }
}