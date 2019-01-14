using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUnlock : MonoBehaviour {

    private void OnEnable()
    {
        StartCoroutine(DisableUnlockPanel());
    }

    IEnumerator DisableUnlockPanel()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    public void OnClickUnlockPanel()
    {
        gameObject.SetActive(false);
    }
}
