using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Explosion : MonoBehaviour
    {
        public static void Explode(Vector2 center, float radius, float force)
        {
            List<Rigidbody2D> bodies = new List<Rigidbody2D>();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius);

            foreach(Collider2D collider in colliders)
            {
                bodies.Add(collider.GetComponent<Rigidbody2D>());
            }
        }
    }
}