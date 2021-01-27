using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    
    public GameObject[] enemies;
    private int n;
    //public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 4f, 6f);
    }


    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
    }
    
    // Update is called once per frame
    void Update()
    {
        /*if (n >= 1)
        {
            CancelInvoke("SpawnEnemy");
        }*/
    }
}
