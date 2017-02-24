using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace UntitledLOL
{
    public class ULNetworkManager : NetworkManager
    {

        public static ULNetworkManager instance
        {
            get { return (ULNetworkManager)singleton; }
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {

            base.OnServerAddPlayer(conn, playerControllerId);
            uint netId = conn.playerControllers[0].unetView.netId.Value;
            Debug.Log("[S]Player connected " + conn.connectionId);
            GameManager.GetInstance().CallEventPlayerConnected(conn.connectionId, netId);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            Debug.Log("[S]Player disconnected: " + conn.connectionId);
            uint? f = GameManager.GetInstance().GetNetIdFromConnectionId(conn.connectionId);

            GameManager.GetInstance().CallEventPlayerDisconnected(conn.connectionId, f.HasValue ? f.Value : uint.MaxValue);
        }

        public override void OnStopServer()
        {
            DestroyImmediate(GameManager.GetInstance().gameObject);
        }

    }

}