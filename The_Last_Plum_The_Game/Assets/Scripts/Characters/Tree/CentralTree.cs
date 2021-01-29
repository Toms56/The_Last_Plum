using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CentralTree : MonoBehaviour
{

    public Camera mainCam;
    
    public float healthPtsTree = 10;

    public bool loseHp;

    public Slider healthBarTree;
    // Start is called before the first frame update
    void Start()
    {
        healthBarTree.value = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (healthPtsTree >= 10)
        {
            healthPtsTree = 10;
        }

        healthBarTree.value = healthPtsTree;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            healthPtsTree -= 1;
            //healthBarTree.value -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPtsTree <= 0)
            {
                Destroy(GameplayManager.Instance.centralTree);
                GameplayManager.Instance.ShowGameOver();
                Time.timeScale = 0;
            }
        }
        
        if (other.gameObject.tag == "InvisibleEnemy")
        {
            Destroy(other.gameObject);
            healthPtsTree -= 1;
            //healthBarTree.value -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPtsTree <= 0)
            {
                Destroy(GameplayManager.Instance.centralTree);
            }
        }
    }
}
