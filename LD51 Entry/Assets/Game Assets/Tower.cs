using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.quinnsgames.ld51
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
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
            float displayedHeight = GetTowerHeight() + 5f;
            _text.text = $"Height: {displayedHeight.ToString("00.0")} m";
        }
    }
}