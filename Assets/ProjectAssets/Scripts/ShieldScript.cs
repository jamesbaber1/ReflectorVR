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
    }

    void OnCollisionEnter(Collision other)
    {

    }
}
