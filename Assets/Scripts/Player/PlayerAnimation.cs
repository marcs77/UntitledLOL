using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class PlayerAnimation : PlayerBase
    {

        Transform model;
        public Transform head;
        public Transform cameraT;
        Vector3 headRot;

        void Start()
        {
            model = transform.FindChild("stickplayer");
            if(model == null)
            {
                throw new Exception("Model not found");
            }
        
            model.gameObject.layer = LayerMask.NameToLayer("LocalPlayer");
            Utils.SetLayerRecursively(model.gameObject, LayerMask.NameToLayer("Default"));

            //head = transform.FindChild("head");
            cameraT = transform.FindChild("FPCamera");

            if(head == null)
            {
                throw new Exception("sdfdsf");
            }

        }


        void Update()
        {
            
        }

        void LateUpdate()
        {

            model.localPosition = new Vector3(0, -1, 0);

            float headTilt = cameraT.localEulerAngles.x;

            if (headTilt >= 310 && headTilt < 360)
            {
                Debug.Log("Dentro arriba");
            }
            else if (headTilt <= 30 && headTilt >= 0)
            {
                Debug.Log("Dentro abajo");
            }
            else
            {
                if (headTilt >= 279 && headTilt < 310)
                {
                    headTilt = 310;
                }
                else if (headTilt > 30 && headTilt < 81)
                {
                    headTilt = 30;
                }
            }


            headRot = new Vector3(head.localEulerAngles.x, headTilt, head.localEulerAngles.z);


            Debug.Log(headTilt);

            head.localEulerAngles = headRot;
        }


    }

}