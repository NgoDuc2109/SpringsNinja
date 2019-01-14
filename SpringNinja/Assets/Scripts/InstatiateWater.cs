using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateWater : MonoBehaviour
{
    [SerializeField]
    private GameObject water;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.PLAYER)
        {
            Vector3 temp = new Vector3( col.gameObject.transform.position.x -1.5f, -2f,0);
            Instantiate(water, temp, Quaternion.identity);
            AudioManager.Instance.PlayFallClip();
        }
    }
}
