using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject[] enemies;
    private int n;
    //public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 6f, 5f);
    }
    
    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameplayManager.Instance.centralTree == null) 
        {
            gameObject.SetActive(false);
        }   
    }
}
