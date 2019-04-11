using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class PistolScript : MonoBehaviour
    {
        public SteamVR_Action_Boolean trigger;
        public GameObject lazer;
        public SteamVR_Input_Sources triggerHand;
        // Start is called before the first frame update
        void Start()
        {
            //trigger.AddOnStateDownListener("firePistol", triggerHand);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (!GameObject.Find("PlayerLazer(Clone)")) Instantiate(lazer, transform.position + (transform.forward * 0.57f) + (transform.up * 0.06f), transform.rotation);
            }
        }

        //void firePistol(OnPressDown, trigger)
        //{

        //}

        
    }
}
