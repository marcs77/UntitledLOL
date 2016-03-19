using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class Billboard : MonoBehaviour
    {
        Transform cam;

        void Start()
        {
            cam = GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().GetLocalPlayer().transform.FindChild("FPCamera");
        }

        void Update()
        {
            transform.LookAt(cam.position);
        }

    }

}