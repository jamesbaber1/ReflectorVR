using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableArea : MonoBehaviour
{

    public GameObject target;
    private Collider current_collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enableRigidbody()
    {
        current_collider.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Pistol") == true || other.CompareTag("Shield") == true)
        {
            Debug.Log("COLLISION WITH THROWABLE AREA DETECTED");
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            current_collider = other;
            Invoke("enableRigidbody", 0.25f);
            other.gameObject.GetComponent<Rigidbody>().AddForce((target.transform.position - other.transform.position) * 100);
        }
    }
}
