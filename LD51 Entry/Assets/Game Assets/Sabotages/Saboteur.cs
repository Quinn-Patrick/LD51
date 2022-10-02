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

        sabotage[] delegates = new sabotage[5];

        private void Awake()
        {
            /*delegates[0] = LaunchMissile;
            delegates[1] = IncreaseGravity;
            delegates[2] = Snakes;
            delegates[3] = Invisible;
            delegates[4] = LaunchMissile;*/
            delegates[0] = LaunchMissile;
            delegates[1] = LaunchMissile;
            delegates[2] = LaunchMissile;
            delegates[3] = LaunchMissile;
            delegates[4] = LaunchMissile;
        }

        private void Update()
        {
            if (!GameTimer.GameActive)
            {
                _timer = 10f;
                return;
            }

            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                delegates[Random.Range(0, delegates.Length)]();
                _timer += 10f;
                delegates[4] = DoNothing;
            }
        }

        private void LaunchMissile()
        {
            SabotageText.Instance.ActivateText("Bomb Inbound!");
            _missilePrefab.SetActive(true);
        }

        private void IncreaseGravity()
        {
            SabotageText.Instance.ActivateText("Gravity Increased!");
            GlobalCharacteristics.Instance.IncreaseGravity(0.5f);
        }


        private void Snakes()
        {
            SabotageText.Instance.ActivateText("It's Raining Snakes!");
            SnakeGenerator.Instance.SpawnSnake();
        }

        private void Invisible()
        {
            SabotageText.Instance.ActivateText("Everything's Invisible!");
            foreach (GameObject obj in BlockPool.GetAllActiveBlocks())
            {
                obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        private void DoNothing()
        {
            SabotageText.Instance.ActivateText("Made You Look!");
        }
    }
}