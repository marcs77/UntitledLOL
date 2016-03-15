using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public abstract class PlayerBase : NetworkBehaviour
    {
        Player _player;
        public Player player
        {
            get {
                if(_player == null)
                {
                    _player = GetComponent<Player>();
                }
                return _player;
            }
        }

        PlayerIdentity _identity;
        public PlayerIdentity identity
        {
            get
            {
                if (_identity == null)
                {
                    _identity = GetComponent<PlayerIdentity>();
                }
                return _identity;
            }
        }

        PlayerMovement _movement;
        public PlayerMovement movement
        {
            get
            {
                if (_movement == null)
                {
                    _movement = GetComponent<PlayerMovement>();
                }
                return _movement;
            }
        }



    }
}
