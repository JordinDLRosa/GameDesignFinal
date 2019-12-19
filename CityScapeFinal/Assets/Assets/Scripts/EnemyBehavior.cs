using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
  public int health = 100;
  public GameObject deathEffect;
  public GameObject Enemy;
  public GameObject MainCharacter;

public void TakeDamage(int damage){
    health -= damage;

    if (health <= 0){
      Die();
    }
  }

    void Die(){
      Instantiate(deathEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }


    public void OnCollisionEnter2D(Collision2D collision) //
    {
        if (Enemy.gameObject.tag == "Enemy")
        {
        }
        if (MainCharacter.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerStats>().PlayerKilled();
            Destroy(gameObject);
        }
    }
}
