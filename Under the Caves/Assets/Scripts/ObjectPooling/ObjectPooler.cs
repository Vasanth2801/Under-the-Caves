using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class objectPool
    {
        public string objectTag;
        public GameObject objectPrefab;
        public int poolSize;
    }

    public objectPool[] pools;
    public Dictionary<string, Queue<GameObject>> poolOfDictionary;

    void Start()
    {
        poolOfDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(objectPool pool in pools)
        {
            Queue<GameObject> obj = new Queue<GameObject>();

            for(int i =0; i<pool.poolSize;i++)
            {
                GameObject objPool = Instantiate(pool.objectPrefab);
                objPool.SetActive(false);
                obj.Enqueue(objPool);
            }

            poolOfDictionary.Add(pool.objectTag, obj);
        }
    }

    public GameObject SpawnFromPools(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objToSpawn = poolOfDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        poolOfDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}