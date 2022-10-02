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
            if (BonusModes.Instance == null)
            {
                _timer = 360;
                return;
            }
            int mode = BonusModes.Instance.gameLength;
            if (mode == 1) _timer = 180;
            else if (mode == 2) _timer = 60;
            else _timer = 360;
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            int minutes = (int)Mathf.Floor(_timer / 60);
            int seconds = (int)_timer - (minutes * 60);
            if(_timer <= 6f)
            {
                _endTextAnimator.SetTrigger("Activate");

                if(GameActive)_endText.text =$"{ seconds }";


                if (_timer <= float.Epsilon)
                {
                    if (_finalScore <= float.Epsilon)
                    {
                        _finalScore = Tower.GetTowerHeight() + 5f;
                    }
                    BlockPool.GetAllActiveBlocks().Clear();
                    GameActive = false;
                    _timer = 1;
                    _endText.text = $"Game Over!\n\nFinal Height: {_finalScore.ToString("#0.0")} m\n\n[Spacebar]";
                    
                }
            }

            if (!GameActive)
            {
                if (_input.Start)
                {
                    GameActive = true;
                    SceneManager.LoadScene(0);
                }
            }

            _timerText.text = $"Time remaining: {minutes.ToString("0")}:{seconds.ToString("00")}";
        }
    }
}