﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.0f;

    [SerializeField] private float moveForce = 1.0f;

    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform playerTransform;


    private Rigidbody2D playerRigidbody2D;

    bool playerLookingRight;

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

    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        playerRigidbody2D.AddForce(new Vector2(moveX, 0) * moveForce * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);

        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletGo;
             bulletGo = Instantiate(bullet, new Vector2(playerTransform.position.x, playerTransform.position.y), Quaternion.identity);
            if (PlayerLookingRight)
                bulletGo.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            else
                bulletGo.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
        }

        if (moveX * moveForce * Time.deltaTime > 0)
        {
            playerLookingRight = true;
        }
        else if (moveX * moveForce * Time.deltaTime < 0)
        {
            playerLookingRight = false;
        }
        Debug.Log(playerLookingRight);
    }
}






/*
CODE DE ADAM:

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.0f;

    [SerializeField] private float moveForce = 1.0f;


    private Rigidbody2D playerRigidbody2D;

    bool playerLookingRight;

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

    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        playerRigidbody2D.AddForce(new Vector2(moveX, 0) * moveForce * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);

        }

        if (moveX * moveForce * Time.deltaTime >= 0.5)
        {
            playerLookingRight = true;
        }
        else if (moveX * moveForce * Time.deltaTime <= -0.5)
        {
            playerLookingRight = false;
        }
        Debug.Log(playerLookingRight);
        //Debug.Log(moveX * moveForce * Time.deltaTime);
    }
}

    */

/*CODE DE SEB
public class PlayerControler : MonoBehaviour
{
[SerializeField] float speed;
[SerializeField] float jumpforce;
float moveInput;

private Rigidbody2D playerRigidbody2D;

bool playerLookingRight;

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

}

void Update()
{

}

private void FixedUpdate()
{
    moveInput = Input.GetAxis("Horizontal");
    playerRigidbody2D.velocity = new Vector2(moveInput * speed, playerRigidbody2D.velocity.y);

    if (moveInput > 0 && !playerLookingRight)
    {
        playerLookingRight = true;
    }
    if (moveInput < 0 && playerLookingRight)
    {
        playerLookingRight = false;
    }
    Debug.Log(playerLookingRight);
}



}


*/
