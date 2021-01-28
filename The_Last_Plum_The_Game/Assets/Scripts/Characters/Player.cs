using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Heal 
    private float playerHealthPts = 2;
    Color willDeath = Color.red;
    
    private GameplayManager gameplayManager;
    [SerializeField]
    Transform target;
    private Vector2 targetPos;
    
    [SerializeField]
    private float speed;
    
    //Monnaie
    [SerializeField] private float currencyFund;
    
    //Ennemy
    //List<GameObject>ennemies = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        gameplayManager = GameplayManager.Instance;
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

        if (Input.GetKeyDown(KeyCode.Space)&& gameplayManager.defenseTowers.Count<4 && currencyFund >= 4)
        {
           GameObject defenseTowerObject = Instantiate(gameplayManager.defenseTower,transform.position,quaternion.identity);
           gameplayManager.defenseTowers.Add(defenseTowerObject);
           currencyFund -= 4;
        }

        if (playerHealthPts <= 0)
        {
            Destroy(gameObject);
            StartCoroutine(WaitForSpawn());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Money")
        {
            currencyFund += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            playerHealthPts -= 1;
            Destroy(other.gameObject);
        }
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(5);
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}
