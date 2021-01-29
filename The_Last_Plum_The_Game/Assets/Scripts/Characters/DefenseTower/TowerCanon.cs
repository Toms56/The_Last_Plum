using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class TowerCanon : MonoBehaviour
{

    public Transform enemyTarget;
    public float range = 7f;

    public string enemyTag = "Enemy";
    
    //shoot
    public float fireRate = 1f;
    private float fireCountDown = 0f; // calcul du délais entre chaque tir

    public GameObject towerBullet;

    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.1f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            
            enemyTarget = nearestEnemy.transform;
        }
        else
        {
            enemyTarget = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyTarget == null)
        {
            return;
        }
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        //Debug.Log("Tir effectué"); 
        GameObject enemyBulletGo = (GameObject) Instantiate(towerBullet, firePoint.position, firePoint.rotation);
        TowerBullet bullet = enemyBulletGo.GetComponent<TowerBullet>();

        if (bullet != null)
        {
            bullet.Seek(enemyTarget);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
