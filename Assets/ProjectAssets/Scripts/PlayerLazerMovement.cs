using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazerMovement : MonoBehaviour
{
    public float destroyTime = 3.0f;
    public float speed = 150.0f;
    //public float range = 50;
    AudioSource hitShieldSound;
    //private Vector3 target;//Just reallly far forward
    void Start()
    {
        //target = transform.position + (range*transform.forward);
        Destroy(gameObject, destroyTime);
        //hitShieldSound = GetComponent<AudioSource>();
        //GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        //gameObject.GetComponent<Rigidbody>().velocity = speed*transform.forward;
    }

    void FixedUpdate()
    {
        //transform.position += (target) / (1 / (speed / 25));
        transform.position += (speed*transform.forward) / 1000;
        //print("Should be moveing");

    }

    void OnCollisionEnter(Collision other)
    {
        /*
        if (other.gameObject.tag == "Lazer")
        {
            Debug.Log("Shield and lazer are colliding");
            //toPlayer = -Vector3.Reflect(other.GetContact(0).point, other.GetContact(0).normal).normalized;
            //toPlayer.y = 0;//shield.transform.position.y;
            //toPlayer.Normalize();
            other.gameObject.GetComponent<LazerMovement>().toPlayer = -other.gameObject.GetComponent<LazerMovement>().toPlayer;
            transform.rotation = Quaternion.LookRotation(other.gameObject.GetComponent<LazerMovement>().toPlayer);
            //get unit normal of sheild and seet the toPlayer equal to that
            //also reset the rotation or call a function that rotates the object over time
        }
        */
    }
}