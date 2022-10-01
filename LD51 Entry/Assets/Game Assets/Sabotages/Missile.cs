using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        private void OnEnable()
        {
            _body.transform.position = new Vector2(30f, Tower.GetTowerHeight());
            _body.velocity = new Vector2(-15f, 0f);
        }

        
    }
}