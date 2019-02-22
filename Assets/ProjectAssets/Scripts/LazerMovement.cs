using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMovement : MonoBehaviour
{

    public GameObject shield;
    public float speed;
    public float maxSpeed;

    private Vector3 toPlayer;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        toPlayer = (shield.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(toPlayer);
        Destroy(gameObject, 2);
        col = GetComponent<Collider>();
        Invoke("EnableCollision", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += (toPlayer) / (1 / (speed / 25));
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Shield") == true)
        {
            Debug.Log("Shield and lazer are colliding");
            toPlayer = -Vector3.Reflect(other.GetContact(0).point, other.GetContact(0).normal).normalized;
            toPlayer.y = 0;//shield.transform.position.y;
            toPlayer.Normalize();
            transform.rotation = Quaternion.LookRotation(toPlayer);
            //get unit normal of sheild and seet the toPlayer equal to that
            //also reset the rotation or call a function that rotates the object over time
        }
    }

    void EnableCollision()
    {
        col.enabled = true;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float f)
    {
        if(f <= maxSpeed)
        {
            speed = f;
        }
    }
}
