using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected static int activeNum;

    public GameObject lazer;
    public float minLazerCooldown;
    public GameObject manager;
    public static int enemiesKilled = 0;

    private bool isActive = false;
    private bool isDead = false;
    //public GameObject light;
    //private Material mat;
    public float lazerCooldown;
    public GameObject spawnPos;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //mat = light.GetComponent<Renderer>().material;
        SpawnLazer();
    }

    // Update is called once per frame
    void Update()
    {

    }


    protected void SpawnLazer()
    {
        if (isActive == true)
        {
            Instantiate(lazer, spawnPos.transform.position, transform.rotation);
            //mat.color = Color.green; //CHANGE LIGHT SOURCE TO ON
        }
        else
        {
            //mat.color = Color.red; //CHANGE LIGHT SOURCE TO OFF
        }
        Invoke("SpawnLazer", lazerCooldown);
    }

    public void setActive(bool a)
    {
        isActive = a;
        if (a == true)
        {
            activeNum++;
        }
        else
        {
            activeNum--;
        }
    }

    public int getActiveNum()
    {
        return activeNum;
    }

    public bool getActive()
    {
        return isActive;
    }

    public bool getDead()
    {
        return isDead;
    }

    public void SetLazerCooldown(float f)
    {
        if (f >= /*0.25f*/minLazerCooldown)
        {
            lazerCooldown = f;
        }
    }

    public void SetLazerSpeed(float f)
    {
        lazer.GetComponent<LazerMovement>().SetSpeed(f);
    }

    public float GetLazerSpeed()
    {
        return lazer.GetComponent<LazerMovement>().GetSpeed();
    }

    public float GetLazerCooldown()
    {
        return lazerCooldown;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lazer") == true)
        {
            Debug.Log("Enemy and lazer are colliding");
            //mat.color = Color.red;
            Destroy(other.gameObject);
            if(isActive == true)
            {
                Debug.Log("ENEMY KILLED");
                enemiesKilled++;
                gameObject.SetActive(false);
                isDead = true;
                isActive = false;
            }
            
        }
    }
}
