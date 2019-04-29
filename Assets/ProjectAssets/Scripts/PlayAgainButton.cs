using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
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
            Debug.Log("Load Level button and laser are colliding");

            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(hitExplode, other.contacts[0].point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(hitExplode, 4.0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // loadLevel.SetActive(true);
            //Destroy(this.gameObject);
            //Application.Quit();
        }
    }
}
