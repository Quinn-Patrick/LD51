using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.quinnsgames.ld51
{
    public class Saboteur : MonoBehaviour
    {
        [SerializeField] private GameObject _missilePrefab;
        [SerializeField] private TextMeshProUGUI _text;
        private delegate void sabotage();
        private float _timer = 10f;

        sabotage[] delegates = new sabotage[3];

        private void Awake()
        {
            delegates[0] = LaunchMissile;
            delegates[1] = IncreaseGravity;
            delegates[2] = Snakes;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                delegates[Random.Range(0, delegates.Length)]();
                _timer += 10f;
            }
            _text.text = _timer.ToString("#.##");
        }

        private void LaunchMissile()
        {
            SabotageText.Instance.ActivateText("Missile Fired!");
            _missilePrefab.SetActive(true);
        }

        private void IncreaseGravity()
        {
            SabotageText.Instance.ActivateText("Gravity Increased!");
            GlobalCharacteristics.Instance.IncreaseGravity(0.1f);
        }


        private void Snakes()
        {
            SabotageText.Instance.ActivateText("It's raining snakes!");
            SnakeGenerator.Instance.SpawnSnake();
        }
    }
}