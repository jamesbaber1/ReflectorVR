using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelShot : MonoBehaviour
{
    public GameObject hitExplode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lazer") == true)
        {
            Debug.Log("Barrel and laser are colliding");
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;

            Destroy(other.gameObject);
            Instantiate(hitExplode, other.contacts[0].point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(hitExplode, 4.0f);
            
        }
    }
}
