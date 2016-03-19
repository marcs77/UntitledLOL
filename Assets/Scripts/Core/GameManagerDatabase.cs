using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public class GameManagerDatabase : NetworkBehaviour
    {

        public Dictionary<uint, GameObject> playerDatabase;
        public GameObject localPlayer;

        public delegate void PlayerConnectionEvent(uint id);
        public event PlayerConnectionEvent OnPlayerConnected;


        void OnEnable()
        {
            
        }

        void OnDisable()
        {

        }

        void Awake()
        {
            playerDatabase = new Dictionary<uint, GameObject>();
        }


        void Update()
        {

        }

        public void SetLocalPlayer(Player p)
        {
            if(localPlayer == null)
            {
                localPlayer = p.gameObject;
                playerDatabase.Add(p.netId.Value, p.gameObject);
                CmdSendPlayerId(p.netId.Value, p.gameObject.name);
            }
        }

        [Command]
        void CmdSendPlayerId(uint id, string playerName)
        {
            if(!playerDatabase.ContainsKey(id))
            {
                playerDatabase.Add(id, GameObject.Find(playerName));
                RpcSendPlayerId(id, playerName);
                CallOnPlayerConnected(id);
            }
        }

        [ClientRpc]
        void RpcSendPlayerId(uint id, string playerName)
        {
            if(id != netId.Value)
            {
                playerDatabase.Add(id, GameObject.Find(playerName));
                CallOnPlayerConnected(id);
            }
        }

        public GameObject GetPlayer(uint id)
        {
            return playerDatabase[id];
        }

        public GameObject GetLocalPlayer()
        {
            return localPlayer;
        }

        void CallOnPlayerConnected(uint id)
        {
            if(OnPlayerConnected != null)
            {
                OnPlayerConnected(id);
            }
        }

    }

}