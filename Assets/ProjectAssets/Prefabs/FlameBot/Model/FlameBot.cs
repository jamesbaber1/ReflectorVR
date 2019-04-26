﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlameBot : MonoBehaviour
{

    public GameObject head;
    private GameObject moveTowards;

    private NavMeshAgent flameBot;
    private Animator Anim;
    private Quaternion rot;

    private int health = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        moveTowards = GameObject.FindGameObjectWithTag("MainCamera");
        flameBot = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        flameBot.SetDestination(moveTowards.transform.position);
    }

    private void Update()
    {
        
        head.transform.LookAt(moveTowards.transform);
        //rot.x = 0.0f;
        //rot.z = 0.0f;
        //rot.y = head.transform.rotation.y;
        //head.transform.rotation = rot;
    }

    float getMaxElement(Vector3 v3)
    {
        return Mathf.Max(Mathf.Max(v3.x, v3.y), v3.z);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lazer") == true)
        {
            Debug.Log("Enemy and lazer are colliding");
            //mat.color = Color.red;
            Destroy(other.gameObject);
            //if (isActive == true)
            //{
            health--;
            if(health <= 0)
            {
                Debug.Log("ENEMY KILLED");
                Enemy.enemiesKilled++;
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
                
                //isDead = true;
                //isActive = false;
            //}

        }
    }
}
