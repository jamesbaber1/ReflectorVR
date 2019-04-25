using System;
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
}
