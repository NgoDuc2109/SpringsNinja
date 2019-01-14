using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject Coin;

    private void OnEnable()
    {
        Coin.SetActive(IsActive());
    }

    private bool IsActive()
    {
        float temp = Random.Range(0,100);
        if (temp<30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
