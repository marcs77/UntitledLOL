using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

namespace UntitledLOL
{
    public class PlayerIdentity : PlayerBase
    {
        [SyncVar]
        public string playerName;

        [SyncVar]
        public Vector3 playerColor;

        void Awake()
        {
            Color c = UnityEngine.Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.4f, 1f);
            playerColor = new Vector3(c.r, c.g, c.b);
        }

        public override void OnStartLocalPlayer()
        {
            CmdSendIdentityToServer(GetName());
            SetIdentity();
        }

        private string GetName()
        {
            return "Player_" + netId.ToString();
        }

        [Command]
        void CmdSendIdentityToServer(string name)
        {
            playerName = name;
        }

        void Update()
        {
            if (transform.name == "" || transform.name == "Player(Clone)")
            {
                SetIdentity();
            }

        }

        void SetIdentity()
        {
            if(isLocalPlayer)
            {
                transform.name = GetName();
            }else
            {
                transform.name = playerName;
            }

            GetComponent<MeshRenderer>().material.color = new Color(playerColor.x, playerColor.y, playerColor.z);
        }

        
    }

}