using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject turretPrefab;
    public float radius;
    public float numberOfTurrets;

    private int turretIterator = 0;
    private float cooldownFrames = 300;
    private List<GameObject> turrets;
    private float frames = 0;
    private bool findTurret = false;

    // Start is called before the first frame update
    void Start()
    {
        turrets = new List<GameObject>();
        float angle = 0;
        int iterations = 0;
        while (iterations < numberOfTurrets)
        {
            Vector3 position = new Vector3(transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle), transform.position.y, transform.position.z + radius * Mathf.Sin(Mathf.Deg2Rad * angle));
            Quaternion rot = Quaternion.AngleAxis(-angle - 90, Vector3.up);
            GameObject o = Instantiate(turretPrefab, position, rot);
            turrets.Add(o);
            angle += (360 / numberOfTurrets);
            iterations++;
        }
        SelectTurrets();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (findTurret == true)
        {
            if (turrets[turretIterator].GetComponent<TurretScript>().getActive() == false)
            {
                activateTurret(turretIterator);
                findTurret = false;
            }
            turretIterator++;
            if (turretIterator >= numberOfTurrets)
            {
                turretIterator = 0;
            }
        }
        else
        {
            frames++;
            if (frames % cooldownFrames == 0)
            {
                if (turretIterator >= numberOfTurrets)
                {
                    turretIterator = 0;
                }
                if (turrets[turretIterator].GetComponent<TurretScript>().getActive() == false)
                {
                    activateTurret(turretIterator);
                    turretIterator++;
                }
                else
                {
                    findTurret = true;
                }
                frames = 0;
                if (cooldownFrames > 10)
                {
                    cooldownFrames -= 10;
                    for (int i = 0; i < numberOfTurrets; i++)
                    {
                        GameObject o = turrets[i];
                        TurretScript t = o.GetComponent<TurretScript>();
                        t.SetLazerCooldown(t.GetLazerCooldown() - 0.1f);
                        t.SetLazerSpeed(t.GetLazerSpeed() + .1f);
                    }
                }

            }
        }
    }

    void SelectTurrets()
    {
        List<GameObject> turretOrder = new List<GameObject>();
        for (int i = 0; i < numberOfTurrets; i++)
        {
            int rand = (int)(Random.value * turrets.Count);
            Debug.Log("index: " + i + " will be: " + rand);
            turretOrder.Add(turrets[rand]);
            turrets.RemoveAt(rand);
        }

        turrets.Clear();
        turrets = turretOrder;
    }

    void activateTurret(int i)
    {
        GameObject o = turrets[i];
        TurretScript t = o.GetComponent<TurretScript>();
        t.setActive(true);
    }

    void deactivateTurret(int i)
    {
        GameObject o = turrets[i];
        TurretScript t = o.GetComponent<TurretScript>();
        t.setActive(false);
    }

}
