using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;

    private Animator animator;
    public GameObject bloodEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage Taken !");
    }

    void OnCollisionEnter2D (Collision2D col){
      if (col.gameObject.tag.Equals ("Bullet")){
        Destroy(col.gameObject);
        Destroy(gameObject);
      }

    }
}
