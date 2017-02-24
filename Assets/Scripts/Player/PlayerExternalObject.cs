using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class PlayerExternalObject : MonoBehaviour
    {
        void Start()
        {
            Player player = GetComponentInParent<Player>();
            if(player != null)
            {
                if (player.isLocalPlayer)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }else
            {
                Debug.Log("Player not found");
            }
        }

    }

}