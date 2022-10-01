using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.quinnsgames.ld51
{
    public class BlockPool : MonoBehaviour
    {
        private static Queue<GameObject> queue = new Queue<GameObject>();
        [SerializeField] private GameObject[] objTemplate;
        [SerializeField] private int count;
        private void Awake()
        {
            for(int i = 0; i < count; i++)
            {
                ReturnObject(Instantiate(objTemplate[Random.Range(0, objTemplate.Length)]));
            }
        }

        public static GameObject GetObject()
        {
            GameObject newObject = queue.Dequeue();
            newObject.SetActive(true);
            return newObject;
        }

        public static void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }
}