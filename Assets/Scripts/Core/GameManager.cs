using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public delegate void PlayerEvent(uint netID);
        public static PlayerEvent OnPlayerDeath;
        public static PlayerEvent OnPlayerConnected;

        void Awake()
        {
            instance = this;
        }

        public void CallOnPlayerDeath(uint netID)
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath(netID);
            }
        }

        void Start()
        {
            
        }


        void Update()
        {

        }

    }

}