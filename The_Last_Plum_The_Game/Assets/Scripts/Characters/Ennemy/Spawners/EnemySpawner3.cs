using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner3 : MonoBehaviour
{
    public GameObject[] enemies;
    private int n;
    //public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 4f, 7f);
    }
    
    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
    }
}
