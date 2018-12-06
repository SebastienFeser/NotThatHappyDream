using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.0f;

    [SerializeField] private float moveForce = 1.0f;

    SpriteRenderer playerRenderer;


    private Rigidbody2D playerRigidbody2D;
    



    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        playerRigidbody2D.AddForce(new Vector2(moveX, 0) * moveForce * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpForce);

        }
    }
}
  
    
