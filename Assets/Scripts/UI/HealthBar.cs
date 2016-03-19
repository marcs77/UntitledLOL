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
            cam = GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().GetLocalPlayer().transform.FindChild("FPCamera");

            barTransform = transform.FindChild("Bar").gameObject.GetComponent<RectTransform>();
            startingWidth = barTransform.sizeDelta.x;
        }

        void LateUpdate()
        {
            transform.LookAt(cam.position);
        }

        public void SetHealth(int health, int maxHealth)
        {
            barTransform.sizeDelta = new Vector2(startingWidth * health / maxHealth, barTransform.sizeDelta.y);
        }


    }

}