using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

  public Transform EnemyPrefab;
  private double i = 0;
  private double j = 0;

    // Update is called once per frame
    void Update()
    {
        i = Time.realtimeSinceStartup;

        if ((i - j) > 1){
          var EnemyTransform = Instantiate(EnemyPrefab) as Transform;

          EnemyTransform.position = new Vector3(Random.Range(702, 2000), 275, 0);
          j = i;
        }
    }
}
