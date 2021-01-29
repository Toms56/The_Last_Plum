using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCanon : MonoBehaviour
{
    //Shoot
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed;

    private Vector2 lookDirection;

    private float lookAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0,0,lookAngle);
        
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = quaternion.Euler(0,0,lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
            Destroy(bulletClone,5f);
        }
       
    }
}
