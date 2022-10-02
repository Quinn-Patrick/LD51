using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class BlockPool : MonoBehaviour
    {
        private Queue<GameObject> queue = new Queue<GameObject>();
        private static List<GameObject> activeBlocks = new List<GameObject>();
        public static Sprite NextSprite;
        [SerializeField] private GameObject[] objTemplate;
        [SerializeField] private int count;
        [SerializeField] private bool _canPreview;
        private void Awake()
        {
            for(int i = 0; i < count; i++)
            {
                ReturnObject(Instantiate(objTemplate[Random.Range(0, objTemplate.Length)]));
            }
            if (_canPreview)
            {
                NextSprite = queue.Peek().transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            }
        }

        private void Update()
        {
            
        }

        public GameObject GetObject()
        {
            GameObject newObject = queue.Dequeue();
            newObject.SetActive(true);
            if (_canPreview)
            {
                NextSprite = queue.Peek().transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            activeBlocks.Add(newObject);
            return newObject;
        }

        public static List<GameObject> GetAllActiveBlocks()
        {
            return activeBlocks;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }
}