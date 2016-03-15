using UnityEngine;
using UnityEngine.Networking;

namespace UntitledLOL {

	public class Player : PlayerBase {

        [SerializeField]
        Behaviour[] localPlayerComponents;

        GameObject cam;
        GameObject hands;

		void Start () {

            if (!isLocalPlayer)
            {
                foreach (Behaviour b in localPlayerComponents)
                {
                    b.enabled = false;
                }
            }
            else
            {
                cam = GameObject.Find("SceneCamero");
                if (cam != null)
                {
                    cam.SetActive(false);
                }
                

                hands = transform.FindChild("FPCamera").FindChild("Hands").gameObject;
                if(hands != null)
                {
                    int layer = LayerMask.NameToLayer("LocalWeapon");
                    hands.layer = layer;

                    Utils.SetLayerRecursively(hands, layer);
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