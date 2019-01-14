using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsManager : MonoBehaviour
{
    public static PoolsManager Instance;
    [SerializeField]
    private ObjectPoolScript[] platform;
    [SerializeField]
    private ObjectPoolScript cloud;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject RetrievePlatformFromPool()
    {
        ObjectPoolScript tempPool;
        GameObject obj;
        tempPool = platform[Random.Range(0,platform.Length)];
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = tempPool.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }

    public GameObject RetrieveCloudFromPool()
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = cloud.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }
}
