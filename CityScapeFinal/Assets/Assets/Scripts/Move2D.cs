using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move2D : MonoBehaviour
{


    public float jumpVelocity = 50f;

    private float movementInputDirection;
    private float movementInputDirectionUp;
    private bool isFacingRight = true;
    private bool isFacingUp = true;

    public float moveSpeed = 500f;
    private bool isJumping;
    private bool isRunning;
    private bool isAttacking;
    private bool isCrouching;
    private bool isRunAttacking;
    public bool isGrounded = false;
  

    public int curHealth;
    public int maxHealth = 3;

    private Rigidbody2D rb;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Jump();
        CheckInput();
        CheckInputUp();
        CheckMovementDirection();
        CheckMovementDirectionUp();
        UpdateAnimations();
        ApplyMovement();
        ApplyMovementUp();
        CheckAttack();
        CheckCrouch();
        CheckAttackRun();
        CheckHurt();

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {

            Die();
        }
    }




    private void UpdateAnimations()
    {
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isCrouching", isCrouching);
        anim.SetBool("isRunAttacking", isRunAttacking);
   
    }

    private void ApplyMovement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

    }

    private void ApplyMovementUp()
    {
        Vector3 movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

    }

    // void Jump(){
    //   if (Input.GetKeyDown(KeyCode.W) && isGrounded == true){
    //       //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 50f), ForceMode2D.Impulse);
    //       GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
    //     }
    //   }

    private void CheckAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isAttacking = false;
        }
    }

    private void CheckAttackRun()
    {
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {
            isRunAttacking = true;

        }
        else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.Space))
        {
            isRunAttacking = false;
        }
    }

    private void CheckCrouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if (movementInputDirection != 0)
        {
            isRunAttacking = true;
        }
        else
        {
            isRunAttacking = false;
        }
    }

    private void CheckMovementDirectionUp()
    {
        if (isFacingUp && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingUp && movementInputDirection > 0)
        {
            Flip();
        }

        if (movementInputDirectionUp != 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxis("Horizontal");
    }

    private void CheckInputUp()
    {
        movementInputDirectionUp = Input.GetAxis("Vertical");
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        isFacingUp = !isFacingUp;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckHurt()
    {

    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }


    void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // public IEnumerator Knockback (float knockDur, float knockbackPwr, Vector3 knockbackDir)
    //{
    //  float timer = 0;

    //while (knockDur > timer)
    //{
    //  timer += Time.deltaTime;
    //Rigidbody2D.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

    //        }
    //      yield return 0;
    //    }
    //}


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            GetComponent<Move2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}

