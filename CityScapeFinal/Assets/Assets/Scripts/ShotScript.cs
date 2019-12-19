using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{

  public int score;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        EnemyScriptV2 hit = otherCollider.gameObject.GetComponent<EnemyScriptV2>();
        if (hit != null){
          Destroy(hit.gameObject);
          Destroy(gameObject);
          PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0)*1);
          if(PlayerPrefs.GetInt("score", 0)>PlayerPrefs.GetInt("hscore", 0)){
            PlayerPrefs.SetInt("hscore", PlayerPrefs.GetInt("score", 0));
          }
        }
    }
}
