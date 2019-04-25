using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameBurst : MonoBehaviour
{
    public GameObject flame;
    public float burstDuration;

    private GameObject instantiatedFlame;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnFlame", burstDuration, burstDuration);
    }

    void spawnFlame()
    {
        instantiatedFlame = (GameObject)Instantiate(flame, transform.position, transform.rotation);
        Destroy(instantiatedFlame, burstDuration);
    }
}
