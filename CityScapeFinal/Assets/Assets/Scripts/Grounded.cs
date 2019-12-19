using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
  GameObject MainCharacter;
    // Start is called before the first frame update
    void Start(){
        MainCharacter = gameObject.transform.parent.gameObject;
    }


    private void OnCollisionEnter2D(Collision2D collision){
      if (collision.collider.tag == "Ground"){
        MainCharacter.GetComponent<Move2D>().isGrounded = true;
      }
    }

    private void OnCollisionExit2D(Collision2D collision){
      if (collision.collider.tag == "Ground"){
        MainCharacter.GetComponent<Move2D>().isGrounded = false;
      }
    }
}
