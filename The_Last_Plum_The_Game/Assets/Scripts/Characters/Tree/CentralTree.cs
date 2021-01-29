using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CentralTree : MonoBehaviour
{

    public Camera mainCam;

    [SerializeField]
    //private bool deadTree;
    //Health
    
    //public static float healthPtsTree = 10;
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
        //Debug.Log(healthPtsTree);
        if (healthPtsTree <= 0 /*== !deadTree*/)
        {
            //deadTree = true;
            GameplayManager.Instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            healthPtsTree -= 1;
            healthBarTree.value -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPtsTree <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        if (other.gameObject.tag == "InvisibleEnemy")
        {
            Destroy(other.gameObject);
            healthPtsTree -= 1;
            healthBarTree.value -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPtsTree <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
