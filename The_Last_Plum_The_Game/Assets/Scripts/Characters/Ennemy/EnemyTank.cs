using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{

    public float speed;
    public GameObject actualTarget;
    private int actualIndex = 0;
    [SerializeField]
    private float healthPts = 8;
    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        wayPoints[0] = GameObject.FindGameObjectWithTag("WayPoint1");
        wayPoints[1] = GameObject.FindGameObjectWithTag("WayPoint2");
        wayPoints[2] = GameObject.FindGameObjectWithTag("WayPoint3");
        wayPoints[3] = GameObject.FindGameObjectWithTag("WayPoint4");
        wayPoints[4] = GameObject.FindGameObjectWithTag("WayPoint5");
        wayPoints[5] = GameObject.FindGameObjectWithTag("WayPointTree");
        actualTarget = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, actualTarget.transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, actualTarget.transform.position, step);
            //Vector3 dir = actualTarget.transform.position - transform.position;
            /*float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector3.right * Time.deltaTime);*/
        }
        else
        {
            if (actualIndex == 0)
            {
               
                actualIndex = 1;
            }
            else if (actualIndex == 1)
            {
              
                actualIndex = 2;
            } 
            else if (actualIndex == 2)
            {
            
                actualIndex = 3;
            }
            else if (actualIndex == 3)
            {
                actualIndex = 4;
            }
            else if (actualIndex == 4)
            {
                
                actualIndex = 5;
            }
            actualTarget = wayPoints[actualIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
