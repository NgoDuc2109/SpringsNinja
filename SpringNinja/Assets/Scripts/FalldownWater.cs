using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalldownWater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            rb.velocity = Vector2.up * Time.deltaTime * speed;
        }
    }
}
