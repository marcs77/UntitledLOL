using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public class PlayerWeapon : PlayerBase
    {
        Transform cam;
        RaycastHit hit;
        [SerializeField]
        GameObject explosion;

        [SerializeField]
        float range = 100;
        [SerializeField]
        float damage = 10;

        void Start()
        {

            if (!isLocalPlayer)
            {
                enabled = false;
            }

            cam = transform.FindChild("FPCamera");

            if (cam == null)
            {
                throw new Exception("Camera not found");
            }

        }


        void Update()
        {
            if (Input.GetButtonDown("Fire"))
            {
                Debug.Log("Attempted shot");
                CmdShoot(cam.TransformPoint(new Vector3(0, 0, .5f)), cam.forward);
            }
        }

        [Command]
        void CmdShoot(Vector3 position, Vector3 direction)
        {
            if (Physics.Raycast(position, direction, out hit, range))
            {
                RpcDrawLine(position, hit.point);
                Player player;
                
                if ((player = hit.transform.GetComponent<Player>()) != null)
                {
                    Debug.Log("Hit " + hit.transform.name + " by " + damage);
                    NetworkServer.Spawn((GameObject)Instantiate(explosion, hit.point, Quaternion.identity));
                } else
                {
                    Debug.Log("Missed " + hit.transform.name);
                }
            }
        }

        [ClientRpc]
        void RpcDrawLine(Vector3 start, Vector3 end) {
            GetComponent<LineRenderer>().SetPosition(0, start);
            GetComponent<LineRenderer>().SetPosition(1, end);
        }
       

    }

}