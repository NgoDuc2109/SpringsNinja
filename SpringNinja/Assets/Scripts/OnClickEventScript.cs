using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class OnClickEventScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.SetPower(true);           
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.SetPower(false);
        }


    }
}
