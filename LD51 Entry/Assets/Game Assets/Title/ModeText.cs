using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.quinnsgames.ld51
{
    public class ModeText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            string saboMode = "";
            string musicMode = "";
            string gameLength = "";
            switch (BonusModes.Instance.sabotageMode)
            {
                case 1: saboMode = "Bombs Only\n"; break;
                case 2: saboMode = "Snakes Only\n"; break;
                case 3: saboMode = "No Sabotage\n"; break;
                default: saboMode = ""; break;
            }
            switch (BonusModes.Instance.musicMode)
            {
                case 1: musicMode = "8-Bit Music\n"; break;
                case 2: musicMode = "Metal Music\n"; break;
                default: musicMode = ""; break;
            }
            switch (BonusModes.Instance.gameLength)
            {
                case 1: gameLength = "3 Minute Game"; break;
                case 2: gameLength = "1 Minute Game"; break;
                default: gameLength = ""; break;
            }
            _text.text = $"{saboMode}{musicMode}{gameLength}";
        }
    }
}