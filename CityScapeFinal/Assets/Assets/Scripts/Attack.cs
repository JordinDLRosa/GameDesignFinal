using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform Bullet;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var posX = gameObject.transform.position.x;
        var posY = gameObject.transform.position.y;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Transform>().position = new Vector2(posX, posY);
            Instantiate(Bullet, new Vector2((posX+1.0f), (posY-.25f)), Bullet.rotation);

        }
    }
}
