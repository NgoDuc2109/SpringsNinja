using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("CreateNewCloud",0,2f);
    }

    public void CreateNewCloud()
    {
        float randomScale = Random.Range(0.1f,0.3f);
        Vector3 temp = new Vector3 (Camera.main.transform.position.x + Camera.main.orthographicSize,Random.Range(0, Camera.main.orthographicSize),0);
        GameObject clone = PoolsManager.Instance.RetrieveCloudFromPool();
        clone.transform.position = temp;
        clone.transform.localScale = new Vector3(randomScale,randomScale,0);
        clone.transform.rotation = Quaternion.identity;
    }
}
