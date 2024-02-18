using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }

        sprite.flipX = dirX switch
        {
            < 0 => true,
            > 0 => false,
            _ => sprite.flipX
        };

        animator.SetBool("running", dirX is > 0 or < 0);
    }

    
}
