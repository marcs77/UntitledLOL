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
        GameObject enemyHitEffect;
        [SerializeField]
        GameObject defaultHitEffect;
        Muzzle muzzle;

        [SerializeField]
        float range = 100;
        [SerializeField]
        int damage = 10;

        public float shootDelay = 0.1f;
        float nextShoot = 0;

        void Start()
        {

            if (!isLocalPlayer)
            {
                enabled = false;
            }

            cam = transform.FindChild("Camera");

            if (cam == null)
            {
                throw new Exception("Camera not found");
            }

            muzzle = cam.GetComponentInChildren<Muzzle>();

        }


        void Update()
        {
            if (Input.GetButton("Fire") && CursorHandler.cursorLocked && nextShoot < Time.time)
            {
                nextShoot = Time.time + shootDelay;
                CmdShoot(cam.TransformPoint(new Vector3(0, 0, .5f)), cam.forward);
                
                muzzle.ShootEffects();
            }
        }

        [Command]
        void CmdShoot(Vector3 position, Vector3 direction)
        {

            RpcMuzzle();

            if (Physics.Raycast(position, direction, out hit, range))
            {
                
                //RpcDrawEffects(position, hit.point);
                Player player;
                
                if ((player = hit.transform.GetComponent<Player>()) != null)
                {
                    Debug.Log("Hit " + hit.transform.name + " by " + damage);

                    GameObject temp = new GameObject();
                    temp.transform.position = hit.point;
                    temp.transform.rotation = Quaternion.LookRotation(hit.normal);
                    temp.transform.Rotate(new Vector3(0, 0, 1), UnityEngine.Random.Range(0, 360));
                    GameObject hitef = (GameObject)Instantiate(enemyHitEffect, hit.point, temp.transform.rotation);

                    
                    NetworkServer.Spawn(hitef);
                    Destroy(temp);
                    player.health.Damage(damage);

                } else
                {
                    GameObject temp = new GameObject();
                    temp.transform.position = hit.point;
                    temp.transform.rotation = Quaternion.LookRotation(hit.normal);
                    temp.transform.Rotate(new Vector3(0, 0, 1), UnityEngine.Random.Range(0, 360));
                    GameObject hitef = Instantiate(defaultHitEffect, hit.point, temp.transform.rotation);
                    
                    
                    NetworkServer.Spawn(hitef);
                    Destroy(temp);
                    hitef.GetComponent<DefaultHitEffect>().SetMaterial(hit.transform.gameObject);
                }
            }
        }

        [ClientRpc]
        void RpcDrawEffects(Vector3 start, Vector3 end) {

            GetComponent<LineRenderer>().SetPosition(0, muzzle.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, end);
        }
       
        [ClientRpc]
        void RpcMuzzle()
        {
            if(!isLocalPlayer)
            {
                muzzle.ShootEffects();
            }
        }

    }

}