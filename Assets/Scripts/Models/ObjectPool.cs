using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class PoolEntry
    {
        public GameObject prefab;
        public int initialSize;
    }

    [SerializeField] private List<PoolEntry> poolEntries;

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var entry in poolEntries)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();

            for (int i = 0; i < entry.initialSize; i++)
            {
                GameObject obj = Instantiate(entry.prefab);
                obj.SetActive(false);
                objectQueue.Enqueue(obj);
            }
            var objISpawn = entry.prefab.GetComponent<ISpawn>();
            switch (objISpawn)
            {
                case Bullet bullet:
                    bullet.Initialize(Vector2.zero, this, null);
                    break;

                case Enemy enemy:
                    enemy.Initialize(null, this, null, null);
                    break;

                default:
                    
                    break;
            }

            var objTag = objISpawn.Tag;
            poolDictionary.Add(objTag, objectQueue);
        }
    }

    public GameObject GetObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        Debug.Log(tag + " pool count: " + poolDictionary[tag].Count);
        if (poolDictionary[tag].Count == 0)
        {
            // Optionally expand the pool dynamically
            Debug.Log("Creating new object in pool: " + tag);
            foreach (var entry in poolEntries)
            {
                var objTag = entry.prefab.GetComponent<ISpawn>().Tag;
                if (objTag == tag)
                {
                    GameObject obj = Instantiate(entry.prefab);
                    obj.SetActive(false);
                    poolDictionary[tag].Enqueue(obj);
                    break;
                }
            }
        }

        GameObject pooledObject = poolDictionary[tag].Dequeue();
        pooledObject.SetActive(true);
        return pooledObject;
    }

    public void ReturnObject(string tag, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError($"Pool with tag {tag} doesn't exist.");
            return;
        }

        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }
}