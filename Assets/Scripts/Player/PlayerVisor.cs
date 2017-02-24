using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlayerVisor : MonoBehaviour
    {
        MeshRenderer mr;

        void Start()
        {
            Player player = GetComponentInParent<Player>();
            mr = GetComponent<MeshRenderer>();
            if (player != null)
            {
                if (player.isLocalPlayer)
                {
                    mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                }
                else
                {
                    mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
            else
            {
                Debug.Log("Player not found");
            }
        }

    }

}