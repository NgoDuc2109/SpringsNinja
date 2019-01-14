using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Die : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.PLAYER)
        {
            Destroy(col.gameObject.transform.root.gameObject);
            Camera.main.gameObject.GetComponent<CameraFollow>().enabled = false;
            UIManager.Instance.ShowGameOverUI();
        }
        if (col.tag == Constant.Tag.PLATFORM)
        {
            col.gameObject.SetActive(false);
            GameManager.Instance.CreateNewPlatform();
            GameManager.Instance.platforms.RemoveAt(0);
        }
    }
}
