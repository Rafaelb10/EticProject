using System.Collections.Generic;
using UnityEngine;

public class PoolManager<gameObjectToSave> where gameObjectToSave : Component
{
    private readonly gameObjectToSave prefab;
    private readonly Queue<gameObjectToSave> pool = new Queue<gameObjectToSave>();

    public PoolManager(gameObjectToSave prefab, int initialSize)
    {
        this.prefab = prefab;

        for (int i = 0; i < initialSize; i++)
        {
            gameObjectToSave obj = GameObject.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public gameObjectToSave Get()
    {
        if (pool.Count == 0)
        {
            gameObjectToSave obj = GameObject.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }

        gameObjectToSave pooledObj = pool.Dequeue();
        pooledObj.gameObject.SetActive(true);
        return pooledObj;
    }

    public void ReturnToPool(gameObjectToSave obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
