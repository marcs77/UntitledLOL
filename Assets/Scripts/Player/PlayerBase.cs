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
            get
            {
                if (_player == null)
                {
                    _player = GetComponentInParent<Player>();
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
                    _identity = GetComponentInParent<PlayerIdentity>();
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
                    _movement = GetComponentInParent<PlayerMovement>();
                }
                return _movement;
            }
        }

        PlayerHealth _health;
        public PlayerHealth health
        {
            get
            {
                if (_health == null)
                {
                    _health = GetComponentInParent<PlayerHealth>();
                }
                return _health;
            }
        }

        PlayerWeapon _weapon;
        public PlayerWeapon weapon
        {
            get
            {
                if (_weapon == null)
                {
                    _weapon = GetComponentInParent<PlayerWeapon>();
                }
                return _weapon;
            }
        }

        public bool IsLocalPlayer()
        {
            return isLocalPlayer;
        }
        
    }

}
