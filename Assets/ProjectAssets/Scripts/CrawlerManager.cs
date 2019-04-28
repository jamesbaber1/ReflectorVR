﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerManager : MonoBehaviour
{
    public GameObject turretPrefab;
    public float radius;
    public float numberOfTurrets;
    //public int maxTurrets;
    public float activationCooldown;
    public float decreaseLazerCooldown;
    public float increaseLazerSpeed;
    public GameObject player;
    public static int maxEnemiesToWin;
    public static bool callElevator = false;

    private bool elevatorCalled = false;
    private int turretIterator = 0;
    private float cooldownFrames = 300;
    private List<GameObject> turrets;
    private float frames = 0;
    private bool findTurret = false;
    private int maxRounds = 3;
    private int round = 1;
    //private bool deactivated = false;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemiesToWin = 4;
        Enemy.enemiesKilled = 0;
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
        //SelectTurrets();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Enemies killed: " + Enemy.enemiesKilled);
        //Debug.Log("Turrets list size: " + turrets.Count);
        if (Enemy.enemiesKilled >= maxEnemiesToWin && round == maxRounds)
        {
            //Debug.Log("YOU WON THE GAME! :D");
            //Enemy.enemiesKilled = 0;
            if (elevatorCalled == false)
            {
                MoveUp.maxVal = 56;
                MoveUp.callElevator = true;
                Enemy.enemiesKilled = 0;
            }
            elevatorCalled = true;
        }
        else if (Enemy.enemiesKilled >= maxEnemiesToWin && round < maxRounds)
        {
            turrets.Clear();
            turretIterator = 0;
            numberOfTurrets = 4;
            Enemy.enemiesKilled = 0;
            round++;
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
            Debug.Log(turrets.Count);
            //SelectTurrets();
        }
        /*
        else
        {
            eraseDead();
            if (findTurret == true)
            {
                //Debug.Log("find turret is true");
                Enemy turret = turrets[turretIterator].GetComponent<Enemy>();
                int badCount = 0;
                while ((turret.getActive() == true ) && badCount <= turrets.Count)
                {
                    badCount++;
                    //Debug.Log("badCount: " + badCount);
                    turretIterator++;
                    if (turretIterator >= turrets.Count)
                    {
                        turretIterator = 0;
                    }
                    turret = turrets[turretIterator].GetComponent<Enemy>();
                }
                //Debug.Log("final badCount: " + badCount);
                if (badCount <= turrets.Count)
                {
                    activateTurret(turretIterator);
                    findTurret = false;
                }
            }
            else
            {
                frames++;
                if (frames >= cooldownFrames)/
                {
                    findTurret = true;
                    frames = 0;
                    if (cooldownFrames >  activationCooldown)
                    {
                        cooldownFrames -= activationCooldown;
                        for (int i = 0; i < turrets.Count; i++)
                        {
                            GameObject o = turrets[i];
                            Enemy t = o.GetComponent<Enemy>();
                            t.SetLazerCooldown(t.GetLazerCooldown() - decreaseLazerCooldown);
                            t.SetLazerSpeed(t.GetLazerSpeed() + increaseLazerSpeed);
                        }
                    }

                }
            }
        }
        */
    }
    
    /*
    void eraseDead()
    {
        for (int i = 0; i < turrets.Count; i++)
        {
            Enemy turret = turrets[i].GetComponent<Enemy>();
            if (turret.getDead() == true)
            {
                turrets.Remove(turret.gameObject);
                Destroy(turret.gameObject);
                numberOfTurrets--;
            }
            if (turretIterator >= turrets.Count)
            {
                turretIterator = 0;
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
    */
}
