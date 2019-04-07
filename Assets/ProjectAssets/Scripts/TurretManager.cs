using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject turretPrefab;
    public float radius;
    public float numberOfTurrets;
    public int maxTurrets;
    public float activationCooldown;
    public float decreaseLazerCooldown;
    public float increaseLazerSpeed;

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
            Quaternion rot = Quaternion.AngleAxis(-angle /*- 90*/, Vector3.up);
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
            if (turrets[turretIterator].GetComponent<Enemy>().getActive() == false)
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
            if (frames >= cooldownFrames )/*&& turrets[turretIterator].GetComponent<TurretScript>().getActiveNum() < maxTurrets)*/
            {
                if (turretIterator >= numberOfTurrets)
                {
                    turretIterator = 0;
                }
                if (turrets[turretIterator].GetComponent<Enemy>().getActive() == false)
                {
                    activateTurret(turretIterator);
                    turretIterator++;
                }
                else
                {
                    findTurret = true;
                }
                frames = 0;
                if (cooldownFrames > /*10*/ activationCooldown)
                {
                    cooldownFrames -= activationCooldown/*10*/;
                    for (int i = 0; i < numberOfTurrets; i++)
                    {
                        GameObject o = turrets[i];
                        Enemy t = o.GetComponent<Enemy>();
                        t.SetLazerCooldown(t.GetLazerCooldown() - /*0.1f*/decreaseLazerCooldown);
                        t.SetLazerSpeed(t.GetLazerSpeed() + /*.1f*/increaseLazerSpeed);
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
            turretOrder.Add(turrets[rand]);
            turrets.RemoveAt(rand);
        }

        turrets.Clear();
        turrets = turretOrder;
    }

    void activateTurret(int i)
    {
        GameObject o = turrets[i];
        Enemy t = o.GetComponent<Enemy>();
        t.setActive(true);
    }

    void deactivateTurret(int i)
    {
        GameObject o = turrets[i];
        Enemy t = o.GetComponent<Enemy>();
        t.setActive(false);
    }

}
