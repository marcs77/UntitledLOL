using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class HealthBar : MonoBehaviour
    {
        Transform cam;

        float startingWidth;
        RectTransform barTransform;

        
        void Start()
        {            
            barTransform = transform.FindChild("Bar").gameObject.GetComponent<RectTransform>();
            startingWidth = barTransform.sizeDelta.x;
        }

        
        void FixedUpdate()
        {
            cam = Camera.main.transform;
        }

        void LateUpdate()
        {

            if (cam != null)
            {
                transform.LookAt(cam.position);
            }
        }

        public void SetHealth(int health, int maxHealth)
        {
            if(barTransform) {
                barTransform.sizeDelta = new Vector2(startingWidth * health / maxHealth, barTransform.sizeDelta.y);
            }
        }


    }

}