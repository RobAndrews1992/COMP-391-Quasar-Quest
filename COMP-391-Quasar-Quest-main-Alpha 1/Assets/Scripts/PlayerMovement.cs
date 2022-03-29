﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private CircleCollider2D circleCollider2D;
    float horizontal = 0f;
    public float speed = 50f;
    public float jumpForce = 10f;
    public LayerMask groundLayers;
    public Transform feet;
    private bool rightWay = true;
    bool jump = false;
 
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 1f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump") && isGrounded()) jump = true;
    }
    
    private void turnFace()
    {
        rightWay = !rightWay;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }
    void FixedUpdate()
    {
        float movement = horizontal * Time.fixedDeltaTime;
        player.velocity = new Vector2(movement * 10f, player.velocity.y);
         
        if (movement > 0 && !rightWay) turnFace();
        else if(movement < 0 && rightWay) turnFace();
 
        if (jump)
        {
            player.velocity = Vector2.up * jumpForce;
            jump = false;
        }
    }  
}
