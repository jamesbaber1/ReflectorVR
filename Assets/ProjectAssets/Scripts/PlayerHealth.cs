﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshPro hText;
    public TextMeshPro sText;
    public TextMeshPro instructionText;
    //public GameObject TurretManager;
    public AudioClip death;
    public static int health = 10;
    public GameObject floor_manager;

    private GameObject[] turrets;
    private GameObject[] lazers;
    private int score = 0;
    private int countDown = 5;
    private AudioSource woundedSound;
    private AudioSource DeathSound;

    public GameObject man1;
    public GameObject man2;
    public GameObject man3;

    private int enemy_tracker;
    private int initial_health = 10;



    private void Start()
    {
        instructionText.text = "PREPARE YOURSELF\n\nGRAB THIS SHIELD";
        InvokeRepeating("InstructionCountDown", 1f, 1f);
        woundedSound = GetComponent<AudioSource>();
        DeathSound = GetComponent<AudioSource>();
        enemy_tracker = Enemy.enemiesKilled;
    }

    void Update()
    {
        if(Enemy.enemiesKilled != enemy_tracker)
        {
            enemy_tracker = Enemy.enemiesKilled;
            setScore();
        }
       
        if(health <= 0)
        {
            //TurretManager.SetActive(false);
            hText.text = "You were killed!";

            //GameObject man1 = GameObject.FindGameObjectWithTag("FirstManager");
            //GameObject man2 = GameObject.FindGameObjectWithTag("SecondManager");
            //GameObject man3 = GameObject.FindGameObjectWithTag("ThirdManager");

            floor_manager.SetActive(false);

            man1.SetActive(false);
            man2.SetActive(false);
            man3.SetActive(false);

            turrets = GameObject.FindGameObjectsWithTag("turret");

            foreach(GameObject g in turrets)
            {
                Destroy(g);
            }
        }
    }




    public void setHealth()
    {
        //Debug.Log("DECREASING HEALTH");
        woundedSound.Play();
        hText.text = "Health " + health;
        //Debug.Log("Health " + health);
    }

    public void setScore()
    {
        //Debug.Log("INCREASING SCORE");
        score++;
        sText.text = "Score " + score;
        //Debug.Log("Score " + score);
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
            floor_manager.SetActive(true);
            instructionText.text = "";
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("PLAYER collided with particles");
        health--;
    }

        public void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.CompareTag("Lazer") == true)
        {
            Debug.Log("PLAYER collided with lazer");
            setHealth();
            health--;
        }
    }

}
