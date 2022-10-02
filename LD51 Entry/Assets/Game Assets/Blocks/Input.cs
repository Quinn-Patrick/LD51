using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Input : MonoBehaviour
    {
        GameControls _controls;
        public float LeftRight;
        public float Rotation;
        public bool Start;

        private void Awake()
        {
            _controls = new GameControls();

            _controls.Gameplay.LeftRight.performed += ctx => LeftRight = ctx.ReadValue<float>();
            _controls.Gameplay.Rotate.performed += ctx => Rotation = ctx.ReadValue<float>();
            _controls.Gameplay.Start.performed += ctx => Start = true;

            _controls.Gameplay.LeftRight.canceled += ctx => LeftRight = 0f;
            _controls.Gameplay.Rotate.canceled += ctx => Rotation = 0f;
            _controls.Gameplay.Start.canceled += ctx => Start = false;
        }

        private void OnEnable()
        {
            _controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            _controls.Gameplay.Disable();
        }
    }
}