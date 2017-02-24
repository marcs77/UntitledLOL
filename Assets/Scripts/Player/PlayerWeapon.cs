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
<<<<<<< HEAD
        GameObject explosion;
=======
        GameObject enemyHitEffect;
        [SerializeField]
        GameObject defaultHitEffect;
        Muzzle muzzle;
>>>>>>> test

        [SerializeField]
        float range = 100;
        [SerializeField]
        int damage = 10;

<<<<<<< HEAD
=======
        public float shootDelay = 0.1f;
        float nextShoot = 0;

>>>>>>> test
        void Start()
        {

            if (!isLocalPlayer)
            {
                enabled = false;
            }

<<<<<<< HEAD
            cam = transform.FindChild("FPCamera");
=======
            cam = transform.FindChild("Camera");
>>>>>>> test

            if (cam == null)
            {
                throw new Exception("Camera not found");
            }

<<<<<<< HEAD
=======
            muzzle = cam.GetComponentInChildren<Muzzle>();

>>>>>>> test
        }


        void Update()
        {
<<<<<<< HEAD
            if (Input.GetButtonDown("Fire"))
            {
                Debug.Log("Attempted shot");
                CmdShoot(cam.TransformPoint(new Vector3(0, 0, .5f)), cam.forward);
=======
            if (Input.GetButton("Fire") && CursorHandler.cursorLocked && nextShoot < Time.time)
            {
                nextShoot = Time.time + shootDelay;
                CmdShoot(cam.TransformPoint(new Vector3(0, 0, .5f)), cam.forward);
                
                muzzle.ShootEffects();
>>>>>>> test
            }
        }

        [Command]
        void CmdShoot(Vector3 position, Vector3 direction)
        {
<<<<<<< HEAD
            if (Physics.Raycast(position, direction, out hit, range))
            {
                RpcDrawLine(position, hit.point);
=======

            RpcMuzzle();

            if (Physics.Raycast(position, direction, out hit, range))
            {
                
                //RpcDrawEffects(position, hit.point);
>>>>>>> test
                Player player;
                
                if ((player = hit.transform.GetComponent<Player>()) != null)
                {
                    Debug.Log("Hit " + hit.transform.name + " by " + damage);
<<<<<<< HEAD
                    GameObject exp = (GameObject)Instantiate(explosion, hit.point, Quaternion.identity);
                    NetworkServer.Spawn(exp);
                    Destroy(exp, 7);

=======

                    GameObject temp = new GameObject();
                    temp.transform.position = hit.point;
                    temp.transform.rotation = Quaternion.LookRotation(hit.normal);
                    temp.transform.Rotate(new Vector3(0, 0, 1), UnityEngine.Random.Range(0, 360));
                    GameObject hitef = (GameObject)Instantiate(enemyHitEffect, hit.point, temp.transform.rotation);

                    
                    NetworkServer.Spawn(hitef);
                    Destroy(temp);
>>>>>>> test
                    player.health.Damage(damage);

                } else
                {
<<<<<<< HEAD
                    Debug.Log("Missed " + hit.transform.name);
=======
                    GameObject temp = new GameObject();
                    temp.transform.position = hit.point;
                    temp.transform.rotation = Quaternion.LookRotation(hit.normal);
                    temp.transform.Rotate(new Vector3(0, 0, 1), UnityEngine.Random.Range(0, 360));
                    GameObject hitef = Instantiate(defaultHitEffect, hit.point, temp.transform.rotation);
                    
                    
                    NetworkServer.Spawn(hitef);
                    Destroy(temp);
                    hitef.GetComponent<DefaultHitEffect>().SetMaterial(hit.transform.gameObject);
>>>>>>> test
                }
            }
        }

        [ClientRpc]
<<<<<<< HEAD
        void RpcDrawLine(Vector3 start, Vector3 end) {
            GetComponent<LineRenderer>().SetPosition(0, start);
            GetComponent<LineRenderer>().SetPosition(1, end);
        }
       
=======
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
>>>>>>> test

    }

}