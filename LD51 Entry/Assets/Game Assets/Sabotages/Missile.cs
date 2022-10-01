using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _timer;
        [SerializeField] private ParticleExplosion _explosion;
        private void Awake()
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            _timer = 5f;
            _body.transform.position = new Vector2(30f, Tower.GetTowerHeight() + 1f);
            _body.velocity = new Vector2(-30f, 0f);
            if(_body.transform.position.y < -7f) gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Explosion.Explode(gameObject.transform.position, 10f, 100f, _layerMask);
            _explosion.transform.position = this.transform.position;
            _explosion.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                //gameObject.SetActive(false);
            }
        }
    }
}