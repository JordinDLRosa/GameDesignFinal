using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpforce;
    public float speed;
    public bool isGrounded;
    public bool isJumping;
    Rigidbody2D rb;
    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void UpdateAnimations(){
        anim.SetBool("isJumping", isJumping);
      }

    void Jump()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        jumpspace();
    }
    void jumpspace()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isGrounded)
        {
            isGrounded = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpforce));
            anim.SetBool("isJumping", true);

        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("im touching ground");
           // rb.velocity = Vector2;
        }
    }


}
