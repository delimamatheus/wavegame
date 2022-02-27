using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> objectList;
    public int amount = 20;

    private void Awake()
    {
        StartPool();
    }

    private void StartPool()
    {
        objectList = new List<GameObject>();
        for(int i = 0; i < amount; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectList.Add(obj);
        }
    }

    public GameObject getListedObject()
    {
        for(int i = 0; i < amount; i++)
        {
            if (!objectList[i].activeInHierarchy)
            {
                return objectList[i];
            }
        }

        return null;
    }
}
