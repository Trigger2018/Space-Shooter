﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float shotSpeed = 7f;

    public GameObject impactEffect;
    public GameObject SpaceExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        if(other.tag =="Space Object")
        {
            Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
        }
        if(other.tag =="Enemy")
        {
            other.GetComponent<EnemyController>().HurtEnemy();
           // Instantiate(SpaceExplosion, other.transform.position, other.transform.rotation);

            
        }

        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
