using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    //private int spawnCount = 3;

    private int n;
    public GameObject enemy;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    //public int n = 0;
    //public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3f, 7f);
    }


    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        /*if (n < 1)
        {
            //enemy.layer = 1000;
            Instantiate(enemy, transform.position, transform.rotation);
            n = n + 1;
        }*/
        
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
