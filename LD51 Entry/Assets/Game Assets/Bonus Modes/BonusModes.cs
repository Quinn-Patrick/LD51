using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.quinnsgames.ld51
{
    public class BonusModes : MonoBehaviour
    {
        public static BonusModes Instance;
        public int sabotageMode = 0;
        public int musicMode = 0;
        public int gameLength = 0;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0) return;
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (sabotageMode == 1) sabotageMode = 0;
                else sabotageMode = 1; //Bombs only mode
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (sabotageMode == 2) sabotageMode = 0;
                else sabotageMode = 2; //Snakes only mode
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (sabotageMode == 3) sabotageMode = 0;
                else sabotageMode = 3; //No Sabotage Mode
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
            {
                if(musicMode == 1) musicMode = 0;
                else musicMode = 1; //8-Bit Mode
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
            {
                if(musicMode == 2) musicMode = 0;
                else musicMode = 2; //Metal Mode
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (gameLength == 1) gameLength = 0;
                else gameLength = 1; //3 Minute Game
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha7))
            {
                if (gameLength == 2) gameLength = 0;
                else gameLength = 2; //1 Minute Game
            }
        }
    }
}