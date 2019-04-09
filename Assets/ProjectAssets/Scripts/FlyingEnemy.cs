using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemy : MovingEnemy
{
    private NavMeshAgent agent;
    private int frameNum = 0;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        radius = Random.Range(5.0f, 20.0f);
        SpawnLazer();
        Vector3 goTo = new Vector3(radius * Mathf.Cos(Random.Range(-2 * Mathf.PI, 2 * Mathf.PI)), transform.position.y, radius * Mathf.Sin(Random.Range(-2 * Mathf.PI, 2 * Mathf.PI)));
        agent.SetDestination(goTo);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(player.transform);
        frameNum++;
        if (frameNum % 300 == 0)
        {
            frameNum = 0;
            Vector3 goTo = new Vector3(radius * Mathf.Cos(Random.Range(-2 * Mathf.PI, 2 * Mathf.PI)), 0, radius * Mathf.Sin(Random.Range(-2 * Mathf.PI, 2 * Mathf.PI)));
            agent.SetDestination(goTo);
        }
    }
}
