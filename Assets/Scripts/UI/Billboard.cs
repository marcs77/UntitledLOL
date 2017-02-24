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
<<<<<<< HEAD
            cam = GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().GetLocalPlayer().transform.FindChild("FPCamera");
=======
            cam = GameManager.GetInstance().localPlayer.transform.FindChild("FPCamera");
>>>>>>> test
        }

        void Update()
        {
            transform.LookAt(cam.position);
        }

    }

}