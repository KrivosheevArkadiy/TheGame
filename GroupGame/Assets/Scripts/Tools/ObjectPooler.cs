using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Helpers;

namespace Assets.Scripts.Tools
{
    /// <summary>
    /// Class for all ObjectPool at scene
    /// </summary>

    public sealed class ObjectPooler : Singleton<ObjectPooler>
    {
        [SerializeField]
        private List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach(Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.GetSize; ++i)
                {
                    GameObject obj = Instantiate(pool.GetPrefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                _poolDictionary.Add(pool.GetTag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(tag))
            {
                return null;
            }

            GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            _poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
