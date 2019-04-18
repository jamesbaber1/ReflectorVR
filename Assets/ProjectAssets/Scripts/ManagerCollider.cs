using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FirstManager") == true)
        {
            //Debug.Log("enter collider 1 manager");
            other.gameObject.GetComponent<TurretManager>().enabled = true;
        }
        else if (other.gameObject.CompareTag("SecondManager") == true)
        {
            //Debug.Log("enter collider 2 manager");
            other.gameObject.GetComponent<CrawlerManager>().enabled = true;
        }
        else if (other.gameObject.CompareTag("ThirdManager") == true)
        {
            //Debug.Log("enter collider 3 manager");
            other.gameObject.GetComponent<FlyingManager>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FirstManager") == true)
        {
            //Debug.Log("enter collider 1 manager");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FirstManager") == true)
        {
            //Debug.Log("exit collider 1 manager");
            other.gameObject.GetComponent<TurretManager>().enabled = false;
        }
        else if (other.gameObject.CompareTag("SecondManager") == true)
        {
            //Debug.Log("exit collider 2 manager");
            other.gameObject.GetComponent<CrawlerManager>().enabled = false;
        }
        else if (other.gameObject.CompareTag("ThirdManager") == true)
        {
            //Debug.Log("exit collider 3 manager");
            other.gameObject.GetComponent<FlyingManager>().enabled = false;
        }

    }
}
