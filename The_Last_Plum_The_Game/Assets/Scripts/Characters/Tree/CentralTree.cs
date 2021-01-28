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
    private bool deadTree;
    //Health
    [SerializeField]
    private float healthPts = 25;

    public bool loseHp;

    public Slider healthBarTree;
    // Start is called before the first frame update
    void Start()
    {
        healthBarTree.value = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPts <= 0 == !deadTree)
        {
            deadTree = true;
            Destroy(gameObject);
            GameplayManager.Instance.ShowGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            healthPts -= 1;
            healthBarTree.value -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        if (other.gameObject.tag == "InvisibleEnemy")
        {
            Destroy(other.gameObject);
            healthPts -= 1;
            healthBarTree.value -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
