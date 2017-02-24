using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
    [RequireComponent(typeof(Camera), typeof(AudioListener))]
    public class SpectatorCamera : NetworkBehaviour
    {

        Camera cam;
        AudioListener lis;

        void OnEnable()
        {

        }

        void OnDisable()
        {

        }

        public override void OnStartClient()
        {
            cam = GetComponent<Camera>();
            lis = GetComponent<AudioListener>();
            Disable();
        }

        void Update()
        {

        }

        void Disable()
        {
            cam.enabled = false;
            lis.enabled = false;
        }

    }

}