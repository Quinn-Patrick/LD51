using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Tower : MonoBehaviour
    {
        public static float GetTowerHeight()
        {
            float height = -5f;
            while(Physics2D.Raycast(new Vector2(-10f, height), new Vector2(1f, 0f), 20f))
            {
                height += 0.1f;
            }
            return height;
        }

        private void Update()
        {
            Debug.Log($"Height: {GetTowerHeight()}");
        }
    }
}