using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

namespace UntitledLOL
{
    [RequireComponent(typeof(ParticleSystemRenderer))]
    public class DefaultHitEffect : NetworkBehaviour
    {

        ParticleSystemRenderer ps;

        void OnEnable()
        {
            ps = GetComponent<ParticleSystemRenderer>();
        }

        void OnDisable()
        {

        }

        void Start()
        {

        }


        void Update()
        {

        }

        [Server]
        public void SetMaterial(GameObject go)
        {
            if (go)
            {
                
                Renderer r = go.GetComponent<Renderer>();
                if (r)
                {
                    ps.material = r.material;
                    RpcUpdateMaterialOnClients(go.name);
                }
            }
        }

        [ClientRpc]
        void RpcUpdateMaterialOnClients(string name)
        {
            GameObject go;
            if (go = GameObject.Find(name))
            {
                Renderer r = go.GetComponent<Renderer>();
                if (r)
                {
                    ps.material = r.material;
                }
            }

            
        }

    }

}