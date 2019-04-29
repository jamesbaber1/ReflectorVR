using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    public GameObject quitButton;
    public GameObject player;
    public GameObject shield;
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
            Debug.Log("UI and lazer are colliding");
            //mat.color = Color.red;
            Destroy(other.gameObject);

            Instantiate(hitExplode, other.contacts[0].point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(hitExplode, 4.0f);

            Destroy(this.gameObject);
            Destroy(quitButton.gameObject);

            shield.SetActive(true);

            player.GetComponent<PlayerHealth>().startGame();
        }
    }
}
