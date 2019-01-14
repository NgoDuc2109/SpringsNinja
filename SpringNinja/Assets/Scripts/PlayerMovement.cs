using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField]
    private GameObject springLeft, springRight;
    [SerializeField]
    private float forceX; // van toc theo truc X
    [SerializeField]
    private float forceY; // van toc theo truc Y
    [SerializeField]
    [Range(0, 50)]
    private float thresHoldX; //Goc theo truc X
    [SerializeField]
    [Range(0, 50)]
    private float thresHoldY; // Goc theo truc Y
    private Rigidbody2D rb;
    private bool isSetPower; // Co luc tac dung khong?
    [SerializeField]
    [Range(0, 1000)]
    private float speed;
    [SerializeField]
    private Transform groundCheckPoint;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private GameObject spritePlayer;
    private bool isGround;
    [SerializeField]
    private float startPosition,lastPosition;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetActiveSpring(false);
        springLeft.transform.localScale = new Vector3(0.25f, 0.05f, 0.5f);
        springRight.transform.localScale = new Vector3(0.25f, 0.05f, 0.5f);
        spritePlayer.transform.localPosition = new Vector3(spritePlayer.transform.localPosition.x, lastPosition, spritePlayer.transform.localPosition.z);
    }
    private void Update()
    {
        SetPower();
        isGround = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer);
    }

    private void SetActiveSpring(bool isActive)
    {
        springLeft.gameObject.GetComponent<SpriteRenderer>().enabled = isActive;
        springRight.gameObject.GetComponent<SpriteRenderer>().enabled = isActive;
    }
    /// <summary>
    /// tinh toan luc nhay
    /// </summary>
    private void SetPower()
    {
        if (isSetPower)
        {
            forceX += thresHoldX * Time.deltaTime;
            forceY += thresHoldY * Time.deltaTime;

            springLeft.transform.localScale -= new Vector3(0, 0.5f * Time.deltaTime, 0);
            if (springLeft.transform.localScale.y < 0.05f)
            {
                springLeft.transform.localScale = new Vector3(0.25f, 0.05f, 1);
            }
            springRight.transform.localScale -= new Vector3(0, 0.5f * Time.deltaTime, 0);
            if (springRight.transform.localScale.y < 0.05f)
            {
                springRight.transform.localScale = new Vector3(0.25f, 0.05f, 1);
            }

            spritePlayer.transform.localPosition -= new Vector3(spritePlayer.transform.localPosition.x, 5f * Time.deltaTime, spritePlayer.transform.localPosition.z);
            if (spritePlayer.transform.localPosition.y < lastPosition)
            {
                spritePlayer.transform.localPosition = new Vector3(spritePlayer.transform.localPosition.x, lastPosition, spritePlayer.transform.localPosition.z);
            }
            if (forceX < 0.2f)
            {
                forceX = 0.2f;
            }

            if (forceX > 5f)
            {
                forceX = 5f;
            }

            if (forceY < 4f)
            {
                forceY = 4f;
            }

            if (forceY > 10f)
            {
                forceY = 10f;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSetPower"></param>
    public void SetPower(bool isSetPower)
    {
        this.isSetPower = isSetPower;
        if (!isSetPower && isGround)
        {
            Jump();
        }
    }

    /// <summary>
    /// Ham thuc hien nhay
    /// </summary>
    private void Jump()
    {
        rb.AddForce(new Vector2(forceX, forceY) * speed);
        AudioManager.Instance.PlayJumpSound();
        forceX = 0;
        forceY = 0;
        SetActiveSpring(false);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == Constant.Tag.PLATFORM)
        {
            SetActiveSpring(true);
            spritePlayer.transform.DOLocalMoveY(startPosition, 0.3f);
            springLeft.transform.DOScaleY(0.25f, 0.3f);
            springRight.transform.DOScaleY(0.25f, 0.3f);

        }
    }

    private int combo;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constant.Tag.COMBO)
        {
            combo++;
        }
        if (col.tag == Constant.Tag.SCORE)
        {
            ScoreManager.Instance.AddScore(combo);
            combo = 0;
        }
    }
}
