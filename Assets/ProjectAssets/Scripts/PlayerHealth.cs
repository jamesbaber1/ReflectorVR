using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshPro hText;
    public TextMeshPro sText;
    public TextMeshPro instructionText;
    public GameObject TurretManager;
    public AudioClip death;


    private GameObject[] turrets;
    private GameObject[] lazers;
    private int health = 10;
    private int score = 0;
    private int countDown = 15;
    private AudioSource woundedSound;
    private AudioSource DeathSound;



    private void Start()
    {
        instructionText.text = "Grab this Shield.";
        InvokeRepeating("InstructionCountDown", 5f, 1f);
        woundedSound = GetComponent<AudioSource>();
        DeathSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(health <= 0)
        {
            TurretManager.SetActive(false);
            hText.text = "You were killed!";

            turrets = GameObject.FindGameObjectsWithTag("turret");
            lazers = GameObject.FindGameObjectsWithTag("Lazer");

            foreach (GameObject turret in turrets)
            {
                turret.SetActive(false);
            }

            foreach (GameObject lazer in lazers)
            {
                lazer.SetActive(false);
            }

        }

    }




    public void decreaseHealth()
    {
        woundedSound.Play();
        health--;
        hText.text = "Health " + health;
        Debug.Log("Health " + health);
    }

    public void increaseScore()
    {
        score++;
        sText.text = "Score " + score;
        Debug.Log("Score " + score);
    }

    private void InstructionCountDown()
    {
        countDown--;

        if(countDown>0)
        {
            instructionText.text = "Training starts in " + countDown + "s";
        }
        else if(countDown == 0)
        {
            TurretManager.SetActive(true);
            instructionText.text = "";
        }
    }

}
