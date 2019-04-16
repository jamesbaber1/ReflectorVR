using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNav : MonoBehaviour
{

    public NavMeshAgent cube;
    // Start is called before the first frame update
    void Start()
    {
        cube.SetDestination(new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
