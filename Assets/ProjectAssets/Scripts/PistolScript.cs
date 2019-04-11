using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class PistolScript : MonoBehaviour
    {

        public GameObject lazer;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (!GameObject.Find("PlayerLazer(Clone)")) Instantiate(lazer, transform.position + (transform.forward * 0.57f) + (transform.up * 0.06f), transform.rotation);
            }
        }
    }
}
