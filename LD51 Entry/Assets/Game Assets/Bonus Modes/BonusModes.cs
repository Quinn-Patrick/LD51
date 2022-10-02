using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class BonusModes : MonoBehaviour
    {
        public static BonusModes Instance;
        public int sabotageMode = 0;
        public int musicMode = 0;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown("f1"))
            {
                sabotageMode = 1; //Bombs only mode
            }
            if (UnityEngine.Input.GetKeyDown("f2"))
            {
                sabotageMode = 2; //Snakes only mode
            }
            if (UnityEngine.Input.GetKeyDown("f3"))
            {
                sabotageMode = 3; //Snakes only mode
            }
            if (UnityEngine.Input.GetKeyDown("f4"))
            {
                musicMode = 1; //8-Bit Mode
            }
            if (UnityEngine.Input.GetKeyDown("f4"))
            {
                musicMode = 2; //Metal Mode
            }
        }
    }
}