using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner3 : MonoBehaviour
{
    public bool moveUp;

    public float speed;
    public GameObject[] powerUps;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp",8f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            transform.Translate(0, 3 * Time.deltaTime * speed, 0); //transform.Translate(x,y,z);
        }
        else
        {
            transform.Translate(0, -3 * Time.deltaTime * speed, 0);

        }

        if (transform.position.y <= -2)
        {
            moveUp = true;
        }

        if (transform.position.y >= 2)
        {
            moveUp = false;
        }
    }
    void SpawnPowerUp()
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, transform.rotation);
    }
}
