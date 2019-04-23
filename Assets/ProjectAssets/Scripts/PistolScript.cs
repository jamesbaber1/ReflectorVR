using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PistolScript : MonoBehaviour
{
    public float coolDownTime = 0.025f;
    public GameObject lazer;
    private bool readyToFire = true;
    public Hand lHand = null;
    public Hand rHand = null;
    public float pulseSeconds = 0.1f;
    public float pulseAmplitude = 50;
    public float pulseFrequency = 50;

    void Update()
    {
        if(SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand) && lHand.currentAttachedObject == gameObject)
        {
            if (readyToFire)
            {
                fire();
                lHand.TriggerHapticPulse(pulseSeconds, pulseFrequency, pulseAmplitude);
            }
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && rHand.currentAttachedObject == gameObject)
        {
            if (readyToFire)
            {
                fire();
                rHand.TriggerHapticPulse(pulseSeconds, pulseFrequency, pulseAmplitude);
            }
        }
    }

    public void fire()
    {
        Instantiate(lazer, transform.position + (transform.forward * 0.57f) + (transform.up * 0.06f), transform.rotation);
        readyToFire = false;
        //lHand.TriggerHapticPulse(pulseSeconds, pulseFrequency, pulseAmplitude);
        StartCoroutine(coolDown());
    }

    public IEnumerator coolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        readyToFire = true;
    }
}