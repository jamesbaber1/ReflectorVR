using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{

    public float moveUpVal = 0.1f;
    public float maxVal = 4;
    public float minVal = -1;
    public bool movingUp = true;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.position.y);
        if(gameObject.transform.position.y >= maxVal)
        {
            movingUp = false;
        }
        else if (gameObject.transform.position.y <= minVal)
        {
            movingUp = true;
        }

        if (movingUp)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + moveUpVal, gameObject.transform.position.z);
        }
        /*
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        */

    }
}
