using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.PLAYER)
        {
            this.gameObject.SetActive(false);
            ScoreManager.Instance.AddCoin();
        }
    }
}
