using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CentralTree : MonoBehaviour
{

    public Camera mainCam;
    [SerializeField]
    private float healthPts = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            healthPts -= 1;
            mainCam.DOShakePosition(0.8f, 0.3f);
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
