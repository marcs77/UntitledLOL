using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace UntitledLOL
{
    public class PlayerHealth : PlayerBase
    {

        [SerializeField]
        private int maxHealth = 100;

        [SyncVar(hook = "OnHealthChange")]
        public int healthPoints;

        HealthBar healthBar;

        void Start()
        {
            healthPoints = maxHealth;
            healthBar = GetComponentInChildren<HealthBar>();
        }

        void OnEnable()
        {
            GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().OnPlayerConnected += PlayerConnected;
        }

        void OnDisable()
        {
            GameObject.Find("GameDatabase").GetComponent<GameManagerDatabase>().OnPlayerConnected -= PlayerConnected;
        }

        private void PlayerConnected(uint id)
        {
            if(isServer && netId.Value != id)
            {
                RpcSendHealth(id, healthPoints);
            }
        }

        [ClientRpc]
        void RpcSendHealth(uint id, int health)
        {
            if(netId.Value == id)
            {
                healthPoints = health;
            }
        }

        public void Damage(int h)
        {

            if(!isServer)
            {
                return;
            }

            healthPoints -= h;

            if (healthPoints <= 0)
            {
                healthPoints = 0;
                GameManager.instance.CallOnPlayerDeath(netId.Value);
            }

        }

        public void Heal(int h)
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

        void OnHealthChange(int health)
        {
            if(healthBar != null)
            {
                healthBar.SetHealth(health, maxHealth);
            }
        }

    }

}