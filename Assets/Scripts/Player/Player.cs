using UnityEngine;
using UnityEngine.Networking;

<<<<<<< HEAD
namespace UntitledLOL {

	public class Player : PlayerBase {
=======
namespace UntitledLOL
{

    public class Player : PlayerBase
    {

        [SyncVar]
        public bool isAlive;
>>>>>>> test

        [SerializeField]
        Behaviour[] localPlayerComponents;

<<<<<<< HEAD
        GameObject cam;
        GameObject hands;
        GameObject visor;
        GameObject healthBar;

        public override void OnStartLocalPlayer()
        {
            CursorHandler.cursorLocked = true;

            cam = GameObject.Find("SceneCamera");
            if (cam != null)
            {
                cam.SetActive(false);
            }

            healthBar = transform.FindChild("HealthBarCanvas").gameObject;
            if(healthBar != null)
            {
                healthBar.SetActive(false);
            }

            hands = transform.FindChild("FPCamera").FindChild("Hands").gameObject;
=======
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
>>>>>>> test
            if (hands != null)
            {
                int layer = LayerMask.NameToLayer("LocalWeapon");
                hands.layer = layer;

                Utils.SetLayerRecursively(hands, layer);
            }

<<<<<<< HEAD
            GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().SetLocalPlayer(this);
            
        }

        void Start () {

=======
            GameManager.GetInstance().SetLocalPlayer(this);
        }

        void Start()
        {
>>>>>>> test
            if (!isLocalPlayer)
            {
                foreach (Behaviour b in localPlayerComponents)
                {
                    b.enabled = false;
                }

<<<<<<< HEAD
                visor = transform.FindChild("Visor").gameObject;
                if(visor != null)
                {
                    visor.layer = LayerMask.NameToLayer("Default");
                }
            }
            
        }


        void OnDisable()
        {
            if (cam != null && isLocalPlayer)
            {
                cam.SetActive(true);
            }
        }



=======
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

>>>>>>> test
    }
}