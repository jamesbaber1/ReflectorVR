using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{

    public GameObject hitExplode;

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
            Debug.Log("UI Quit and lazer are colliding");
            
            Destroy(other.gameObject);
            Instantiate(hitExplode, other.contacts[0].point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(hitExplode, 4.0f);
            //Destroy(this.gameObject);

            Application.Quit();
        }
    }
}
