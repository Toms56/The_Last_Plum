using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class InvisibleEnnemy : MonoBehaviour
{
    
    //movement
    public Transform target;
    public GameObject actualTarget;
    public float speed;
    
    //Health
    private float healthPts = 2;
    
    //RevealSprite
    float Delay;
    Color colorBegin;
    Color colorEnd;
    void Awake()
    {
        colorBegin =  new Color(colorBegin.r, colorBegin.g, colorBegin.b, 0f);
        colorEnd = GetComponent<SpriteRenderer>().color;
    }

    private void Start()
    {
        StartCoroutine(Untouchable());
    }

    void Update()
    {
        Delay += Time.deltaTime;
        GetComponent<SpriteRenderer>().color = Color.Lerp(colorBegin, colorEnd, Delay * 0.1f);

        if (transform.GetComponent<SpriteRenderer>().color.a==0)
        {
            GameObject.Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, actualTarget.transform.position) > 0.1f)
        {
            Vector3 dir = actualTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthPts -= 1;
            if (healthPts <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    IEnumerator Untouchable()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
