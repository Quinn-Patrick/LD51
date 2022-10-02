using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class Preview : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Image _sprite;

        private void Update()
        {
            _sprite.sprite = BlockPool.NextSprite;
            _sprite.rectTransform.sizeDelta = new Vector2(BlockPool.NextSprite.bounds.size.x, BlockPool.NextSprite.bounds.size.y) * 20;
        }
    }
}