using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptV2 : MonoBehaviour
{

  public Vector2 speed = new Vector2(10, 0);
  public Vector2 direction = new Vector2(-1,0);

  private Vector2 movement;

  private Move2D player;

    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        if(transform.position.x < Camera.main.transform.position.x -10){
          Destroy(gameObject);
       }
    }

    void FixedUpdate(){
      GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collider){
      if (collider.CompareTag("Player")){
            ScoreScript.scoreValue += 10;
            Destroy(gameObject);

      //      StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));

            }
      }
    }

