using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator anim;
    public float movementSpeed;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    float mx;
    public Transform feet;
    public LayerMask groundLayers;

    public void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
        if(Mathf.Abs(mx)> 0.05f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if(mx > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(mx < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        anim.SetBool("isGrounded", isGrounded());
    }

    private void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if(groundCheck != null)
        {
            return true;
        }
        return false;
    }
}
