using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private void LateUpdate()
    {
        if (this.gameObject.activeInHierarchy)
        {
            transform.position += new Vector3(Random.Range(-1,-0.5f),0,0) *Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.MAINCAMERA)
        {
            gameObject.SetActive(false);
        }        
    }
}
