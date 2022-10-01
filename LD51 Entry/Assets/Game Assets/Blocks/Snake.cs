using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        private void OnEnable()
        {
            _body.transform.position = new Vector2(0f, Tower.GetTowerHeight() + 15f);
        }
        private void Update()
        {
            _body.gravityScale = GlobalCharacteristics.Instance.GetGravity();
        }
    }
}