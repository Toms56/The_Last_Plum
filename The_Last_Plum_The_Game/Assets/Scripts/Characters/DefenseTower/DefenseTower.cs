using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseTower : MonoBehaviour
{
    private GameplayManager gameplayManager;
    [SerializeField]
    private float healthPts = 4;
    
    public Slider healthBarTower;

    public bool isShooting;

    //public GameObject towerBullet;
    // Start is called before the first frame update
    void Start()
    {
        gameplayManager = GameplayManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTowerBullet()
    {
       // Instantiate(towerBullet, transform.position, Quaternion.identity);
    }

    public void StartShooting()
    {
        InvokeRepeating("SpawnTowerBullet", 2f, 0.40f);
    }

    public void StopShooting()
    {
        CancelInvoke("SpawnTowerBullet");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            healthPts -= 1;
            //healthBarTower.value -= 1;
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isShooting = true;
            StartShooting();
            //GameObject towerBulletObject = Instantiate(towerBullet, transform.position, Quaternion.identity);
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D other)
    {
        isShooting = false;
        StopShooting();
    }*/
}
