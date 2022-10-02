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
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private AudioClip _sabotageClip;
        private delegate void sabotage();
        private float _timer = 8.25f;

        sabotage[] delegates = new sabotage[6];

        private void Awake()
        {
            delegates[0] = LaunchMissile;
            delegates[1] = IncreaseGravity;
            delegates[2] = Snakes;
            delegates[3] = Invisible;
            delegates[4] = LaunchMissile;
            delegates[5] = Shake;

            delegates[0] = Snakes;
            delegates[1] = Snakes;
            delegates[2] = Snakes;
            delegates[3] = Snakes;
            delegates[4] = Snakes;
            delegates[5] = Snakes;
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
                _soundPlayer.PlaySoundWithVolume(_sabotageClip, 3.0f);
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
                SpriteRenderer _render = obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
                if (_render == null) continue;
                _render.enabled = false;
            }
        }

        private void Shake()
        {
            SabotageText.Instance.ActivateText("Shaky Shaky!");
            GlobalCharacteristics.Instance.CameraShake = 0.5f;
            GlobalCharacteristics.Instance.CameraShakeTimer = 2f;
        }

        private void DoNothing()
        {
            SabotageText.Instance.ActivateText("Made You Look!");
        }
    }
}