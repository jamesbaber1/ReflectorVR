using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    float rotateBy = 5f;
    float rotateY;
    // Start is called before the first frame update
    void Start()
    {
        rotateY = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotate left");
            rotateY -= rotateBy;
            transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate right");
            rotateY += rotateBy;
            transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);
        }
        */
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
