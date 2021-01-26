using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    Transform target;
    private Vector2 targetPos;
    
    [SerializeField]
    private float speed;
    
    //Ennemy
    List<GameObject>ennemies = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = targetPos;
        }

        if ((Vector2) transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        
    }

    /*void SpawnBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }*/
    
}
