using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.quinnsgames.ld51
{
    [CreateAssetMenu(fileName = "ControlParameters", menuName = "ScriptableObjects/ControlParameters", order = 1)]
    public class ControlParameters : ScriptableObject
    {
        public float LeftRightForce;
        public float RotationForce;
    }
}