using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> background;
    public static int temp;
    private void Start()
    {
        temp = (int)Random.Range(1, 5.9f);
        background[temp -1].SetActive(true);
    }
}
