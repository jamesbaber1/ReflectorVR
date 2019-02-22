using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public GameObject lazer;

    private bool isActive = false;
    private Material mat;
    public float lazerCooldown;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        SpawnLazer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnLazer()
    {
        if(isActive == true)
        {
            Instantiate(lazer, transform.position, transform.rotation);
            mat.color = Color.green;
        }
        else
        {
            mat.color = Color.red;
        }
        Invoke("SpawnLazer", lazerCooldown);
    }

    public void setActive(bool a)
    {
        isActive = a;
    }

    public bool getActive()
    {
        return isActive;
    }

    public void SetLazerCooldown(float f)
    {
        if(f >= 0.25f)
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
            Debug.Log("Turret and lazer are colliding");
            isActive = false;
            mat.color = Color.red;
            Destroy(other.gameObject);
        }
    }
}
