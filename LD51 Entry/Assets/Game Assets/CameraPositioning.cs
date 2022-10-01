using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class CameraPositioning : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private float _adjustmentSpeed;

        private void Update()
        {
            if (_camera == null) return;
            if (_camera.transform.position.y < Tower.GetTowerHeight())
            {
                _camera.transform.position += new Vector3(0f, _adjustmentSpeed * Time.deltaTime, 0f);
            }
            else if(_camera.transform.position.y > Tower.GetTowerHeight())
            {
                _camera.transform.position -= new Vector3(0f, _adjustmentSpeed * Time.deltaTime, 0f);
            }
            
        }
    }
}