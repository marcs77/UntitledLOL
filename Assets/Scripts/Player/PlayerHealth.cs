using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public class PlayerHealth : PlayerBase
    {

        [SerializeField]
        public int maxHealth = 100;

        [SyncVar(hook = "OnHealthChange")]
        public int healthPoints = 100;

        HealthBar healthBar;

        [SerializeField]
        Component[] componentDisableOnDeath;

        [SerializeField]
        GameObject[] gameObjectDisableOnDeath;

        [SerializeField]
        GameObject explosion;

        public delegate void HealthEvent(int amount);
        public event HealthEvent OnPlayerDamage;

        void Start()
        {
            healthBar = GetComponentInChildren<HealthBar>();
            UpdateHealthBar();
        }

        [Server]
        public void Damage(int h)
        {

            if(player.isAlive)
            {
                if (!isServer)
                {
                    return;
                }

                healthPoints -= h;

                if (healthPoints <= 0)
                {
                    healthPoints = 0;
                    player.isAlive = false;
                    GameManager.GetInstance().CallEventPlayerDeath(connectionToClient.connectionId, netId.Value);
                }
            }

        }



        public void Heal(int h)
        {

            if(player.isAlive)
            {
                if (!isServer)
                {
                    return;
                }

                healthPoints += h;
                if (healthPoints > maxHealth)
                {
                    healthPoints = maxHealth;
                }

            }
        }

        void OnHealthChange(int health)
        {
            int temp = healthPoints;

            healthPoints = health;
            UpdateHealthBar();

            if (temp - health > 0)
            {
                if(OnPlayerDamage != null)
                {
                    OnPlayerDamage(temp - health);
                }
            }

            //Debug.Log("h update " + healthPoints + " p: "+name+" "+(isServer ? "server" : isLocalPlayer ? "localplayer" : "client"));
        }

        void UpdateHealthBar()
        {
            if (healthBar != null)
            {
                healthBar.SetHealth(healthPoints, maxHealth);
            }
        }

        public void Kill()
        {
            Damage(maxHealth);
        }

        public void Death()
        {
            if(componentDisableOnDeath.Length != 0)
            {
                foreach (var c in componentDisableOnDeath)
                {
                    Utils.SetEnabledComponent(c, false);
                }
            }

            if(gameObjectDisableOnDeath.Length != 0)
            {
                foreach (var g in gameObjectDisableOnDeath)
                {
                    g.SetActive(false);
                }
            }

            if(isServer)
            {
                GameObject g = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
                NetworkServer.Spawn(g);
                Destroy(g, 4f);
            }

            if(isLocalPlayer)
            {
                UIHandler.singleton.ActivateUI("Respawn");
            }

        }


        public void Respawn()
        {
            if(!player.isAlive)
            {
                if (componentDisableOnDeath.Length != 0)
                {
                    foreach (var c in componentDisableOnDeath)
                    {
                        Utils.SetEnabledComponent(c, true);
                    }
                }

                if (gameObjectDisableOnDeath.Length != 0)
                {
                    foreach (var g in gameObjectDisableOnDeath)
                    {
                        g.SetActive(true);
                    }
                }

                player.SetupRespawn();

                Transform spawnPos = NetworkManager.singleton.GetStartPosition();

                transform.position = spawnPos.position;
                transform.rotation = spawnPos.rotation;

                healthPoints = maxHealth;
                player.isAlive = true;


            }
        }

    }

}