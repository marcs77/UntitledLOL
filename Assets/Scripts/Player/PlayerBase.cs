using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public abstract class PlayerBase : NetworkBehaviour
    {

<<<<<<< HEAD
        Player _player;
        public Player player
        {
            get {
                if(_player == null)
                {
                    _player = GetComponent<Player>();
=======
        

        Player _player;
        public Player player
        {
            get
            {
                if (_player == null)
                {
                    _player = GetComponentInParent<Player>();
>>>>>>> test
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
<<<<<<< HEAD
                    _identity = GetComponent<PlayerIdentity>();
=======
                    _identity = GetComponentInParent<PlayerIdentity>();
>>>>>>> test
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
<<<<<<< HEAD
                    _movement = GetComponent<PlayerMovement>();
=======
                    _movement = GetComponentInParent<PlayerMovement>();
>>>>>>> test
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
<<<<<<< HEAD
                    _health = GetComponent<PlayerHealth>();
=======
                    _health = GetComponentInParent<PlayerHealth>();
>>>>>>> test
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
<<<<<<< HEAD
                    _weapon = GetComponent<PlayerWeapon>();
=======
                    _weapon = GetComponentInParent<PlayerWeapon>();
>>>>>>> test
                }
                return _weapon;
            }
        }

<<<<<<< HEAD
    }
=======
        public bool IsLocalPlayer()
        {
            return isLocalPlayer;
        }
        
    }

>>>>>>> test
}
