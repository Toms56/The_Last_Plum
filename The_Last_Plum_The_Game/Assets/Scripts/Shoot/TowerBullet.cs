using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    private GameplayManager gameplayManager;
    private Transform enemyTarget;

    public GameObject impactEffet;
    public float speed = 70f;

    public void Seek(Transform _enemyTarget)
    {
        enemyTarget = _enemyTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = enemyTarget.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime; // distance à effectuer sur une image
        
        if (dir.magnitude <= distanceThisFrame) //dir.magnitude représente la distance entre la balle et l'enemy
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //normaliser sert à garder la même vitesse tout au long du parcour de l'objet
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffet, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
    }
}
