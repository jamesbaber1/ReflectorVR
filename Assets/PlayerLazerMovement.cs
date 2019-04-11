﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazerMovement : MonoBehaviour
{
    public float speed = 1000.0f;
    AudioSource hitShieldSound;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);
        //col = GetComponent<Collider>();
        hitShieldSound = GetComponent<AudioSource>();
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
