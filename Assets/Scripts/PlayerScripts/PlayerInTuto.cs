using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInTuto : MonoBehaviour
{
    float moveX;
    bool jump;
    bool fire;
    [SerializeField] private float jumpForce = 1.0f;

    [SerializeField] private float moveForce = 1.0f;

    [SerializeField] SpriteRenderer playerSpriteRenderer;

    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform playerTransform;
    [SerializeField] AnimationClip running;
    //[SerializeField] Image lifeBar;
    //[SerializeField] float health = 100;
    float lifeBarOriginalFillSize;


    private Rigidbody2D playerRigidbody2D;

    bool playerLookingRight;
    bool facingRight = true;

    public bool PlayerLookingRight
    {
        get
        {
            return playerLookingRight;
        }
    }




    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerLookingRight = true;
        //lifeBarOriginalFillSize = lifeBar.fillAmount;

    }
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jump = true;
        if (Input.GetButtonDown("Fire1"))
            fire = true;
        if (moveX != 0)
        {
        }
    }

    void FixedUpdate()
    {

        playerRigidbody2D.AddForce(new Vector2(moveX, 0) * moveForce * Time.deltaTime);

        if (jump)
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);
            jump = false;

        }

        if (fire)
        {
            GameObject bulletGo;
            if (PlayerLookingRight)
            {
                bulletGo = Instantiate(bullet, new Vector2(playerTransform.position.x + 0.9f, playerTransform.position.y + 0.2f), Quaternion.identity);
                bulletGo.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            }
            else
            {
                bulletGo = Instantiate(bullet, new Vector2(playerTransform.position.x - 0.9f, playerTransform.position.y + 0.2f), Quaternion.identity);
                bulletGo.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
            }
            fire = false;
        }

        if (moveX * moveForce * Time.deltaTime > 0)
        {
            playerLookingRight = true;
        }
        else if (moveX * moveForce * Time.deltaTime < 0)
        {
            playerLookingRight = false;
        }

        if (facingRight == false && moveX > 0)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        else if (facingRight == true && moveX < 0)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }

}
