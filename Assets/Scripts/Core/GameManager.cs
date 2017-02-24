using UnityEngine;
<<<<<<< HEAD
using System.Collections;
=======
using System.Collections.Generic;
>>>>>>> test
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
<<<<<<< HEAD
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
            
=======

    public class GameManager : NetworkBehaviour
    {

        public delegate void PlayerEvent(int connectionId, uint netId);
        [SyncEvent]
        public event PlayerEvent EventPlayerDeath;
        [SyncEvent]
        public event PlayerEvent EventPlayerRespawn;
        [SyncEvent]
        public event PlayerEvent EventPlayerConnected;
        [SyncEvent]
        public event PlayerEvent EventPlayerDisconnected;

        public event PlayerEvent EventLocalPlayerDeath;
        public event PlayerEvent EventLocalPlayerRespawn;

        private Player _localPlayer;
        public Player localPlayer
        {
            get { return _localPlayer; }
        }

        public void SetLocalPlayer(Player p)
        {
            _localPlayer = p;
        }

        public Dictionary<uint, Player> playerDatabase;
        [SerializeField]
        private Player[] players;

        void OnEnable()
        {
            //DontDestroyOnLoad(gameObject);
            EventPlayerConnected += OnPlayerConnect;
            EventPlayerDisconnected += OnPlayerDisconnect;
            EventPlayerDeath += OnPlayerDeath;
            EventPlayerRespawn += OnPlayerRespawn;

            playerDatabase = new Dictionary<uint, Player>();
        }

        void OnDisable()
        {
            EventPlayerConnected -= OnPlayerConnect;
            EventPlayerDisconnected -= OnPlayerDisconnect;
            EventPlayerDeath -= OnPlayerDeath;
            EventPlayerRespawn -= OnPlayerRespawn;

        }

        void Start()
        {
            playerDatabase = new Dictionary<uint, Player>();

            foreach (Player p in FindObjectsOfType<Player>())
            {
                playerDatabase.Add(p.netId.Value, p);
            }
            UpdateArray();

        }

        [Server]
        public void CallEventPlayerConnected(int connectionId, uint netId)
        {
            if (EventPlayerConnected != null)
            {
                EventPlayerConnected(connectionId, netId);
            }
        }

        [Server]
        public void CallEventPlayerDisconnected(int connectionId, uint netId)
        {
            if (EventPlayerDisconnected != null)
            {
                EventPlayerDisconnected(connectionId, netId);
            }
        }

        [Server]
        public void CallEventPlayerDeath(int connectionId, uint netId)
        {
            if (EventPlayerDeath != null)
            {
                EventPlayerDeath(connectionId, netId);
            }

        }

        [Server]
        public void CallEventPlayerRespawn(int connectionId, uint netId)
        {
            if (EventPlayerRespawn != null)
            {
                EventPlayerRespawn(connectionId, netId);
            }

        }


        static GameManager gm;
        public static GameManager GetInstance()
        {

            if (!gm)
            {
                GameManager[] gms = FindObjectsOfType<GameManager>();

                if (gms.Length == 0)
                {
                    return null;
                }

                if (gms.Length > 1)
                {
                    throw new Exception("Duplicate GameManager");
                }
                gm = gms[0];
            }

            return gm;
>>>>>>> test
        }


        void Update()
        {

        }

<<<<<<< HEAD
=======
        void OnPlayerConnect(int connectionId, uint netId)
        {

            Debug.Log("[COM]Player connected: " + connectionId);

            foreach (Player p in FindObjectsOfType<Player>())
            {
                if (p.netId.Value == netId && !playerDatabase.ContainsKey(netId))
                {
                    playerDatabase.Add(netId, p);
                }
            }


            UpdateArray();
        }

        void OnPlayerDisconnect(int connectionId, uint netId)
        {

            Debug.Log("[COM]Player disconnected: " + connectionId);

            if (netId != uint.MaxValue)
            {
                playerDatabase.Remove(netId);
            }
            else
            {
                Debug.LogWarning("Player could not be removed.");
            }

            UpdateArray();
        }

        void OnPlayerDeath(int connectionId, uint netId)
        {
            Debug.Log("[COM]Player died: " + connectionId);
            playerDatabase[netId].health.Death();

            if (netId == localPlayer.netId.Value && EventLocalPlayerDeath != null)
            {
                EventLocalPlayerDeath(connectionId, netId);
            }

        }

        void OnPlayerRespawn(int connectionId, uint netId)
        {
            Debug.Log("[COM]Player respawned: " + connectionId);
            playerDatabase[netId].health.Respawn();

            if (netId == localPlayer.netId.Value)
            {
                if(EventLocalPlayerRespawn != null)
                {
                    EventLocalPlayerRespawn(connectionId, netId);
                }
                
                UIHandler.singleton.TryClose("Respawn");
            }

        }

        void UpdateArray()
        {
            List<Player> temp = new List<Player>();
            foreach (KeyValuePair<uint, Player> pair in gm.playerDatabase)
            {
                temp.Add(pair.Value);
            }

            players = temp.ToArray();
        }

        [Server]
        public uint? GetNetIdFromConnectionId(int connectionId)
        {
            foreach (KeyValuePair<uint, Player> pair in gm.playerDatabase)
            {
                if (pair.Value.connectionToClient.connectionId == connectionId)
                {
                    return pair.Key;
                }
            }
            return null;
        }


        [Client]
        public void RequestRespawn()
        {
            localPlayer.RequestRespawn();
        }

>>>>>>> test
    }

}