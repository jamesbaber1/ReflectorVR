using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollider : MonoBehaviour
{

    private float cooldown = (60 * 4);
    private bool startCooldown = false;
    private float frameNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startCooldown)
        {
            frameNum++;
            if(frameNum >= cooldown)
            {
                startCooldown = false;
                frameNum = 0;
                PlayerHealth.hitByFlame = false;
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("PARTICLE COLLISION DETECTED");
        //Debug.Log("collision with: " + other.tag);
        if(other.CompareTag("Pistol") == true && !startCooldown)
        {
            //Debug.Log("PARTICLES collided with particles");
            PlayerHealth.health -= 25;
            //Debug.Log("Player health: " + PlayerHealth.health);
            startCooldown = true;
            PlayerHealth.hitByFlame = true;
        }
        
    }
}
