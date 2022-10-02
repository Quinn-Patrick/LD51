using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private Input _input;
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private ControlParameters _controlParameters;
        [SerializeField] private float _maxFallSpeed;
        private float _invisibilityTimer = 5f;
        private SpriteRenderer _spriteRenderer;
        private float _lrForce;
        private float _rotForce;
        private bool _controlled;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _lrForce = _controlParameters.LeftRightForce;
            _rotForce = _controlParameters.RotationForce;
        }
        private void OnEnable()
        {
            _controlled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EndBlockControl();
        }

        private void EndBlockControl()
        {
            if (!_controlled) return;
            BlockGenerator.Instance.StartSpawnTimer();
            _controlled = false;
        }

        private void FixedUpdate()
        {
            if (!_spriteRenderer.enabled)
            {
                _invisibilityTimer -= Time.fixedDeltaTime;
                if(_invisibilityTimer < 0)
                {
                    _spriteRenderer.enabled = true;
                    _invisibilityTimer = 5f;
                }
            }

            _body.gravityScale = 0.8f;
            if(transform.position.y < -5f)
            {
                EndBlockControl();
            }
            _maxFallSpeed = GlobalCharacteristics.Instance.GetGravity();

            if (!_controlled) return;

            _body.gravityScale *= 0.5f;

            if(_body.velocity.y < -_maxFallSpeed)
            {
                _body.velocity = new Vector2(_body.velocity.x, -_maxFallSpeed);
            }

            _body.AddForce(new Vector2(_input.LeftRight * _lrForce, 0f), ForceMode2D.Impulse);
            _body.MoveRotation(_body.rotation + (_rotForce * _input.Rotation * Time.fixedDeltaTime));

            if(Mathf.Abs(_body.velocity.x) > _lrForce)
            {
                _body.AddForce(new Vector2((Mathf.Abs(_body.velocity.x) - _lrForce) * -Mathf.Sign(_body.velocity.x), 0f), ForceMode2D.Impulse);
            }

            if(Mathf.Abs(_input.LeftRight) <= float.Epsilon)
            {
                if (_body.velocity.x > 0.1f)
                {
                    _body.AddForce(new Vector2(-_body.velocity.x, 0f), ForceMode2D.Impulse);
                }
                else
                {
                    _body.velocity = new Vector2(0f, _body.velocity.y);
                }
            }
        }

    }
}