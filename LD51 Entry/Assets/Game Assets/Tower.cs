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
            int attempts = 0;
            while (Physics2D.OverlapBox(new Vector2(0f, height), new Vector2(1000f, 0.1f), 0f) != null)
            {
                attempts++;
                if (attempts > 1000) break;
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