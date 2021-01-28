using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTest : MonoBehaviour
{

    private float healthPts = 2;
    
    public GameObject actualTarget;
    //public GameObject nextTarget;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //actualTarget = GameplayManager.Instance.centralTree;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, actualTarget.transform.position) > 0.1f)
        {
            Vector3 dir = actualTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D other)
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
    }*/

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

        if (other.gameObject.tag == "DefenseTower")
        {
            
        }
    }
}
