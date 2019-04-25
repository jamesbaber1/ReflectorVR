using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LazerMovement : MonoBehaviour
{


    public float speed;
    public float maxSpeed;
    public AudioClip hitShield;
    public Material mat;

    private GameObject Player;
    private GameObject target;
    public Vector3 toPlayer;
    private Collider col;
    private Vector3 initialPos;
    private float laserDistance;
    private PlayerHealth playerInfo;
    AudioSource hitShieldSound;

    // Start is called before the first frame update
    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        toPlayer = (target.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(toPlayer);
        Destroy(gameObject, 4);
        col = GetComponent<Collider>();
        //this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        initialPos = transform.position;
        Invoke("EnableCollision", 0.25f);
        Player = GameObject.Find("Player");
        playerInfo = Player.GetComponent<PlayerHealth>();
        hitShieldSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        laserDistance = Vector3.Distance(target.transform.position, this.transform.position);

        if (laserDistance < 0.05f)
        {
           playerInfo.decreaseHealth();
        }
        */
    }

    void FixedUpdate()
    {
        transform.position += (toPlayer) / (1 / (speed / 25));
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Shield") == true)
        {
            Debug.Log("Shield and lazer are colliding");

            //toPlayer = -Vector3.Reflect(other.GetContact(0).point, other.GetContact(0).normal).normalized;
            //toPlayer.y = 0;//shield.transform.position.y;
            //toPlayer.Normalize();
            //this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //Invoke("disableKinematic", 0.25f);

            toPlayer = (initialPos - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(toPlayer);

            //playerInfo.increaseScore();

            hitShieldSound.clip = hitShield;
            hitShieldSound.Play();
            MeshRenderer r = this.gameObject.GetComponent<MeshRenderer>();
            r.material = mat;
            //r.material.shader = Shader.Find("_Color");
            //r.material.SetColor("_Color", new Color(0.09019607f, 0.9372549f, 0.8509804f));
            //get unit normal of sheild and seet the toPlayer equal to that
            //also reset the rotation or call a function that rotates the object over time
        }
        Debug.Log("in lazer movement collide (name) : " + other.collider.gameObject.name);
        if (other.gameObject.CompareTag("NullifyArea") == true)
        {
            
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("LAZER collided with player");
            //playerInfo.decreaseHealth();
            PlayerHealth.health--;
        }

        }

    void EnableCollision()
    {
        col.enabled = true;
        //this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float f)
    {
        if (f <= maxSpeed)
        {
            speed = f;
        }
    }
}

