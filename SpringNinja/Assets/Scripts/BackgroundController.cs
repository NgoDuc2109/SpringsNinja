using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private GameObject bg1, bg2;
    [SerializeField]
    private float offset;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Constant.Tag.PLAYER)
        {
            if (bg1 == this.gameObject)
            {
                bg2.transform.position = new Vector3(bg2.transform.position.x + offset, bg2.transform.position.y, bg2.transform.position.z);
            }
            else if (bg2 == this.gameObject)
            {
                bg1.transform.position = new Vector3(bg1.transform.position.x + offset, bg1.transform.position.y, bg1.transform.position.z);
            }

        }
    }
}
