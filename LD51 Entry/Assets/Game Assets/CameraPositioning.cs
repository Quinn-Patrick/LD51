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
            _camera.transform.position = new Vector3(0f, _camera.transform.position.y, -10f);
            if (_camera.transform.position.y < Tower.GetTowerHeight())
            {
                _camera.transform.position += new Vector3(0f, _adjustmentSpeed * Time.deltaTime, 0f);
            }
            else if(_camera.transform.position.y > Tower.GetTowerHeight())
            {
                _camera.transform.position -= new Vector3(0f, _adjustmentSpeed * Time.deltaTime, 0f);
            }

            if (GlobalCharacteristics.Instance.CameraShakeTimer > 0f)
            {
                _camera.transform.position += new Vector3(Random.Range(
                    -GlobalCharacteristics.Instance.CameraShake, GlobalCharacteristics.Instance.CameraShake),
                    Random.Range(-GlobalCharacteristics.Instance.CameraShake, GlobalCharacteristics.Instance.CameraShake),
                    0f);
            }
        }
    }
}