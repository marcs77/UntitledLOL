using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{

    public class KillY : MonoBehaviour
    {


        public float threshold = -100f;
        private Transform myTransform;

        void Awake()
        {
            myTransform = transform;
        }

        void Update()
        {
            if (myTransform.position.y < threshold)
            {
                myTransform.position = new Vector3(0, 1, -5);
            }
        }
    }
}