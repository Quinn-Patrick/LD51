using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Explosion : MonoBehaviour
    {
        public static void Explode(Vector2 center, float radius, float force, LayerMask _mask)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius, _mask);

            foreach(Collider2D collider in colliders)
            {
                Rigidbody2D effectedBody = collider.GetComponent<Rigidbody2D>();
                float xDist = effectedBody.transform.position.x - center.x;
                float yDist = effectedBody.transform.position.y - center.y;
                float dist = Mathf.Sqrt(xDist * xDist + yDist * yDist);
                float angle = Mathf.Atan2(yDist, xDist);
                float totalForce = force / (dist * dist);

                float xForce = totalForce * Mathf.Cos(angle);
                float yForce = totalForce * Mathf.Sin(angle);

                effectedBody.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
            }
        }
    }
}