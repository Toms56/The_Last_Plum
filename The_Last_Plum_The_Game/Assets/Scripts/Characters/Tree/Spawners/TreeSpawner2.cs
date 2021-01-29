using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner2 : MonoBehaviour
{
    public float speed;

    public bool moveLeft;
    public GameObject[] powerUps;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp",5f,8f);
    }


    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(3 * Time.deltaTime * speed, 0 , 0); //transform.Translate(x,y,z);
        }
        else
        {
            transform.Translate(-3 * Time.deltaTime * speed, 0 , 0);

        }

        if (transform.position.x <= -1)
        {
            moveLeft = true;
        }

        if (transform.position.x >= 1)
        {
            moveLeft = false;
        }
    }
    void SpawnPowerUp()
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, transform.rotation);
    }
    
}
