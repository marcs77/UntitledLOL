using UnityEngine;
using UnityEngine.Networking;

namespace UntitledLOL
{

    public class Player : PlayerBase
    {

        [SyncVar]
        public bool isAlive;

        [SerializeField]
        Behaviour[] localPlayerComponents;

        Transform cam;
        GameObject hands;
        GameObject visor;
        Transform healthBar;

        public override void OnStartServer()
        {
            isAlive = true;
        }

        public override void OnStartLocalPlayer()
        {

            CursorHandler.cursorLocked = true;


            healthBar = transform.FindChild("HealthBarCanvas");
            if (healthBar != null)
            {
                healthBar.gameObject.SetActive(false);
            }

            cam = transform.FindChild("Camera");
            if (cam != null)
            {
                cam.tag = "MainCamera";
            }

            hands = cam.FindChild("Hands").gameObject;
            if (hands != null)
            {
                int layer = LayerMask.NameToLayer("LocalWeapon");
                hands.layer = layer;

                Utils.SetLayerRecursively(hands, layer);
            }

            GameManager.GetInstance().SetLocalPlayer(this);
        }

        void Start()
        {
            if (!isLocalPlayer)
            {
                foreach (Behaviour b in localPlayerComponents)
                {
                    b.enabled = false;
                }

            }
        }

        public void SetupRespawn()
        {


            if (!isLocalPlayer)
            {
                foreach (Behaviour b in localPlayerComponents)
                {
                    b.enabled = false;
                }
            }else
            {
                healthBar = transform.FindChild("HealthBarCanvas");
                if (healthBar != null)
                {
                    healthBar.gameObject.SetActive(false);
                }
            }

        }

        [ServerCallback]
        void FixedUpdate()
        {
            if (transform.position.y < -20 && isAlive)
            {
                health.Kill();
            }
        }

        [Client]
        public void RequestRespawn()
        {
            CmdRequestRespawn(connectionToServer.connectionId, netId.Value);
        }


        [Command]
        void CmdRequestRespawn(int connectionId, uint netId)
        {
            //TODO: poner cooldown
            GameManager.GetInstance().CallEventPlayerRespawn(connectionId, netId);
        }

    }
}