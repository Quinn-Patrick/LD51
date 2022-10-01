using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.quinnsgames.ld51
{
    public class SabotageText : MonoBehaviour
    {
        public static SabotageText Instance;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Animator _animator;
        private void Awake()
        {
            Instance = this;
        }

        public void ActivateText(string text)
        {
            _text.text = text;
            _animator.SetTrigger("Activate");
        }
    }
}