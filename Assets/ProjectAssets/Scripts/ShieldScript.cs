using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ShieldScript : MonoBehaviour
{

    float rotateBy = 5f;
    float rotateY;

    public Hand lHand = null;
    public Hand rHand = null;
    bool firstTimeGrabbed = false;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rotateY = transform.rotation.y;

        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void Update()
    {

        if ((SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.LeftHand) && lHand.currentAttachedObject == gameObject) || (SteamVR_Actions._default.GrabGrip.GetState(SteamVR_Input_Sources.RightHand) && rHand.currentAttachedObject == gameObject))
        {
            if (firstTimeGrabbed == false)
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }
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
