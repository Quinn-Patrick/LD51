using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.quinnsgames.ld51
{
    public class Scroll : MonoBehaviour
    {
        private float _timer = 0f;
        [SerializeField] private float _speed;
        [SerializeField] private RectTransform _transform;
        [SerializeField] private Input _input;

        private void Update()
        {
            if (_input.Start)
            {
                SceneManager.LoadScene(1);
            }
            _timer += Time.deltaTime;
            if(_timer > 5f)
            {
                _transform.position += new Vector3(0f, _speed * Time.deltaTime, 0f);
            }
        }

    }
}