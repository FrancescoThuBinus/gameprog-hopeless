using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SpriteFlip(float yInput)
    {
        if(yInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        float yInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(yInput*speed*Time.deltaTime,0f,0f));
        SpriteFlip(yInput);

        if(Input.GetKeyDown(KeyCode.Space)&& Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }

    }









} //end public class
