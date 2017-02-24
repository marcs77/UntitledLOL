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

<<<<<<< HEAD
        void Start()
        {
            cam = GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().GetLocalPlayer().transform.FindChild("FPCamera");

=======
        
        void Start()
        {            
>>>>>>> test
            barTransform = transform.FindChild("Bar").gameObject.GetComponent<RectTransform>();
            startingWidth = barTransform.sizeDelta.x;
        }

<<<<<<< HEAD
        void LateUpdate()
        {
            transform.LookAt(cam.position);
=======
        
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
>>>>>>> test
        }

        public void SetHealth(int health, int maxHealth)
        {
<<<<<<< HEAD
            barTransform.sizeDelta = new Vector2(startingWidth * health / maxHealth, barTransform.sizeDelta.y);
=======
            if(barTransform) {
                barTransform.sizeDelta = new Vector2(startingWidth * health / maxHealth, barTransform.sizeDelta.y);
            }
>>>>>>> test
        }


    }

}