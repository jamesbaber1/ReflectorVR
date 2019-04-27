using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingManager : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        Enemy.enemiesKilled = 0;
        maxEnemiesToWin = 16;
        turrets = new List<GameObject>();
        float angle = 0;
        int iterations = 0;
        while (iterations < numberOfTurrets)
        {
            Vector3 position = new Vector3(transform.position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle), transform.position.y, transform.position.z + radius * Mathf.Sin(Mathf.Deg2Rad * angle));
            Quaternion rot = Quaternion.LookRotation(player.transform.position - gameObject.transform.position, Vector3.up);//Quaternion.AngleAxis(-angle - 90, Vector3.up);
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
        //Debug.Log("Enemies killed: " + Enemy.enemiesKilled);
        //Debug.Log("Turrets list size: " + turrets.Count);
        if (Enemy.enemiesKilled >= maxEnemiesToWin)
        {
            //Debug.Log("YOU WON THE GAME! :D");
            //Enemy.enemiesKilled = 0;
            if (elevatorCalled == false)
            {
                MoveUp.maxVal = 77.5f;
                MoveUp.callElevator = true;
                Enemy.enemiesKilled = 0;
            }
            elevatorCalled = true;
        }
        else
        {
            eraseDead();
            if (findTurret == true)
            {
                //Debug.Log("find turret is true");
                Enemy turret = turrets[turretIterator].GetComponent<Enemy>();
                int badCount = 0;
                while ((turret.getActive() == true || !isInFOV(turret)) && badCount <= turrets.Count)
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
                if (frames >= cooldownFrames)/*&& turrets[turretIterator].GetComponent<TurretScript>().getActiveNum() < maxTurrets)*/
                {
                    findTurret = true;
                    frames = 0;
                    if (cooldownFrames > /*10*/ activationCooldown)
                    {
                        cooldownFrames -= activationCooldown/*10*/;
                        for (int i = 0; i < turrets.Count; i++)
                        {
                            GameObject o = turrets[i];
                            Enemy t = o.GetComponent<Enemy>();
                            ////////////////////////////////////////////t.SetLazerCooldown(t.GetLazerCooldown() - /*0.1f*/decreaseLazerCooldown);
                            ////////////////////////////////////////////t.SetLazerSpeed(t.GetLazerSpeed() + /*.1f*/increaseLazerSpeed);
                        }
                    }

                }
            }
        }
    }

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

    public bool isInFOV(Enemy e)
    {
        //Debug.Log("Camera Forward: " + Camera.main.transform.forward);
        //Debug.Log("Enemy Forward: " + e.gameObject.transform.forward);
        //Debug.Log("Dot product: " + Vector3.Dot(e.gameObject.transform.forward, Camera.main.transform.forward));
        if (Vector3.Dot(e.gameObject.transform.forward, Camera.main.transform.forward) <= 0)
        {
            //Debug.Log("This enemy is within the camera's field of view!");
            return true;
        }
        else
        {
            return false;
        }
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
