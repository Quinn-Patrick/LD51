using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace com.quinnsgames.ld51
{
    public class GameTimer : MonoBehaviour
    {
        private float _timer;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _endText;
        [SerializeField] private Animator _endTextAnimator;
        [SerializeField] private Input _input;
        private float _finalScore = 0;
        public static GameTimer Instance;
        public static bool GameActive = true;

        private void Awake()
        {
            Instance = this;
            _timer = 360;
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            int minutes = (int)Mathf.Floor(_timer / 60);
            int seconds = (int)_timer - (minutes * 60);
            if(_timer <= 0f)
            {
                if(_finalScore <= float.Epsilon)
                {
                    _finalScore = Tower.GetTowerHeight() + 5f;
                }
                GameActive = false;
                _timer = 1;
                _endText.text = $"Game Over!\n\nFinal Height: {_finalScore.ToString("#0.0")} m\n\n[Spacebar]";
                _endTextAnimator.SetTrigger("Activate");
            }

            if (!GameActive)
            {
                if (_input.Start)
                {
                    SceneManager.LoadScene(0);
                }
            }

            _timerText.text = $"Time remaining: {minutes.ToString("0")}:{seconds.ToString("00")}";
        }
    }
}