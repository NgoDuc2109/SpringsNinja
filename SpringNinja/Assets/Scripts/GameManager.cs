using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> platforms;
    [SerializeField]
    private GameObject[] player;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float minY;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
        CreateInitialPlatform(PlayerPrefs.GetInt(Constant.PlayerInfo.CURRENTPLAYER));
    }
    public void CreateInitialPlatform(int number)
    {
        for (int i = 0; i < 6; i++)
        {
            if (i==0)
            {
                GameObject clone = PoolsManager.Instance.RetrievePlatformFromPool();
                clone.transform.position = new Vector3(0, Random.Range(minY, maxY), 0);
                clone.transform.rotation = Quaternion.identity;
                clone.transform.GetChild(2).gameObject.SetActive(false);
                clone.transform.GetChild(3).gameObject.SetActive(false);
                platforms.Add(clone);
            }
            else
            {
                float distance = Random.Range(minX,maxX);
                GameObject clone = PoolsManager.Instance.RetrievePlatformFromPool();
                clone.transform.position = new Vector3(platforms[i-1].transform.position.x + distance, Random.Range(minY, maxY), 0);
                clone.transform.rotation = Quaternion.identity;
                platforms.Add(clone);
            }
        }
        Vector3 temp = new Vector3(platforms[0].transform.position.x, platforms[0].transform.position.y + 20f, 0);
        Instantiate(player[number], temp, Quaternion.identity);
    }

    public void CreateNewPlatform()
    {
        float distance = Random.Range(minX, maxX);
        GameObject clone = PoolsManager.Instance.RetrievePlatformFromPool();
        clone.transform.position = new Vector3(platforms[platforms.Count -1].transform.position.x + distance, Random.Range(minY, maxY), 0);
        clone.transform.rotation = Quaternion.identity;
        platforms.Add(clone);
    }
}
