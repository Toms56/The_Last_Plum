using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]private SpriteRenderer spriteRenderer;

    //Heal 
    [SerializeField]
    private float playerHealthPts = 3;
    
    Color willDeath = Color.red;
    
    private GameplayManager gameplayManager;
    [SerializeField]
    Transform target;
    private Vector2 targetPos;
    
    
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        gameplayManager = GameplayManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = targetPos;
        }
        if ((Vector2) transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& gameplayManager.defenseTowers.Count<4 && gameplayManager.currencyFund >= 4)
        {
           GameObject defenseTowerObject = Instantiate(gameplayManager.defenseTower,transform.position,quaternion.identity);
           gameplayManager.defenseTowers.Add(defenseTowerObject);
           gameplayManager.currencyFund -= 4;
        }

        if (playerHealthPts <= 0)
        {
            playerHealthPts = 0; 
            StartCoroutine(WaitForSpawn());
        }

        StartCoroutine(WaitForWin());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Money")
        {
            gameplayManager.currencyFund += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            playerHealthPts -= 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "LifeUp")
        {
            //GameplayManager.Instance.CentralTree.healthPtsTree += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SpeedUp")
        {
            StartCoroutine(SpeedUp());
            Destroy(other.gameObject);
        }
    }

    IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(45);
        GameplayManager.Instance.ShowWonLevel();
    }

    IEnumerator SpeedUp()
    {
        speed += 2;
        yield return new WaitForSeconds(5);
        speed -= 2;
    }

    IEnumerator WaitForSpawn()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(5);
        spriteRenderer.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        playerHealthPts = 3;
    }
}
