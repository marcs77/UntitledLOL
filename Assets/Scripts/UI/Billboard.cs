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
            cam = GameManager.GetInstance().localPlayer.transform.FindChild("FPCamera");
        }

        void Update()
        {
            transform.LookAt(cam.position);
        }

    }

}