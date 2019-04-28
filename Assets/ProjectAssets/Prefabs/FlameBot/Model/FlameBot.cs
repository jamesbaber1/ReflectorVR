using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlameBot : MonoBehaviour
{
    public GameObject hitExplode;
    public GameObject deathExplode;
    public GameObject head;
    private GameObject moveTowards;

    private NavMeshAgent flameBot;
    private Animator Anim;
    private Quaternion rot;

    public GameObject matObj;
    public Material hitMat;
    public Material origMat;

    private int health = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        moveTowards = GameObject.FindGameObjectWithTag("MainCamera");
        flameBot = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        flameBot.SetDestination(moveTowards.transform.position);
    }

    private void Update()
    {
        
        head.transform.LookAt(moveTowards.transform);
        //rot.x = 0.0f;
        //rot.z = 0.0f;
        //rot.y = head.transform.rotation.y;
        //head.transform.rotation = rot;
    }

    float getMaxElement(Vector3 v3)
    {
        return Mathf.Max(Mathf.Max(v3.x, v3.y), v3.z);
    }

    void revertMaterial()
    {
        matObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] { origMat };
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lazer") == true)
        {
            Debug.Log("Enemy and lazer are colliding");

            Instantiate(hitExplode, other.contacts[0].point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(hitExplode, 4.0f);

            //mat.color = Color.red;
            Destroy(other.gameObject);
            //if (isActive == true)
            //{
            health--;

            matObj.GetComponent<SkinnedMeshRenderer>().materials = new Material[] { hitMat };
            Invoke("revertMaterial", 0.1f);

            if (health == 0)
            {
                Debug.Log("ENEMY KILLED");
                Instantiate(deathExplode, other.contacts[0].point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                Destroy(deathExplode, 4.0f);
                Enemy.enemiesKilled++;
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
                
                //isDead = true;
                //isActive = false;
            //}

        }
    }
}





            

                
