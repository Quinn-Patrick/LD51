using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        private float _invisibilityTimer = 5f;
        private SpriteRenderer _spriteRenderer;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnEnable()
        {
            _body.transform.position = new Vector2(0f, Tower.GetTowerHeight() + 15f);
        }
        private void FixedUpdate()
        {
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