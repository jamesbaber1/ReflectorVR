using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazerMovement : MonoBehaviour
{
    private float destroyTime = 7.0f;
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
        transform.position += (speed * transform.forward) / 1000;
        //print("Should be moveing");

    }

    /*
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("in player lazer movement collide (name) : " + other.collider.gameObject.name);
        if (other.gameObject.CompareTag("NullifyArea") == true)
        {
            Destroy(this.gameObject);
        }
    }
    */
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Shield") == true)
        {
            Destroy(this.gameObject);

            Debug.Log("your shooting your shield");
        }
    }


}