using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Die", 0.1f);
    }

    void Die(){
      Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
