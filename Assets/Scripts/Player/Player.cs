using UnityEngine;
using UnityEngine.Networking;

namespace UntitledLOL {

	public class Player : PlayerBase {

        [SerializeField]
        Behaviour[] localPlayerComponents;

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
            if (hands != null)
            {
                int layer = LayerMask.NameToLayer("LocalWeapon");
                hands.layer = layer;

                Utils.SetLayerRecursively(hands, layer);
            }

            GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().SetLocalPlayer(this);
            
        }

        void Start () {

            if (!isLocalPlayer)
            {
                foreach (Behaviour b in localPlayerComponents)
                {
                    b.enabled = false;
                }

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



    }
}