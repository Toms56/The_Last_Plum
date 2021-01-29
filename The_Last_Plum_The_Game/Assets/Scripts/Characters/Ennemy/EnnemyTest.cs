using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTest : MonoBehaviour
{

    private int actualIndex = 0;


    private GameObject actualTarget;
    public GameObject finalTarget;
    //public GameObject player;
    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();
    [SerializeField]
    private float healthPts = 6;


    //public GameObject nextTarget;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints[0] = GameObject.FindGameObjectWithTag("WayPoint6");
        wayPoints[1] = GameObject.FindGameObjectWithTag("WayPointTree");
        actualTarget = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, actualTarget.transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, actualTarget.transform.position, step);
        }
        else
        {
            if (actualIndex == 0)
            {

                actualIndex = 1;
            }
            actualTarget = wayPoints[actualIndex];
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthPts -= 1;
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DefenseTower")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "TowerBullet")
        {
            healthPts -= 1;
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
