using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace UntitledLOL {

	public class HUDCombat : MonoBehaviour {

        public Text healthText;
        public Slider healthSlider;
        private PlayerHealth health;

        private int currentHealth;
        public float healthSmooth = 12f;
        private Animator hurtEffect;

        public Text pickupText;
        public bool showPickupText = false;
        public string pickupName;

        void OnEnable()
        {
            if(GameManager.GetInstance())
            {

                GameManager.GetInstance().EventLocalPlayerDeath += GameOver;
                GameManager.GetInstance().EventLocalPlayerRespawn += Respawn;

            }
            
            
            hurtEffect = transform.FindChild("HurtEffect").GetComponent<Animator>();


        }

        void Start()
        {
            health = GameManager.GetInstance().localPlayer.health;
            health.OnPlayerDamage += HealthChange;

            HealthChange(0);
            UpdateHealthSlider();
        }

        void OnDisable()
        {
            if (health)
            {
                health.OnPlayerDamage -= HealthChange;
            }

            if(GameManager.GetInstance())
            {
                GameManager.GetInstance().EventLocalPlayerDeath -= Respawn;
                GameManager.GetInstance().EventLocalPlayerDeath -= GameOver;
            }

        }

        public void HealthChange(int change)
        {

            currentHealth = health.healthPoints;

            if (healthText != null)
            {
                healthText.text = health.healthPoints + "/" + health.maxHealth;
            }

            if(hurtEffect != null)
            {
                if(change > 0)
                {
                    hurtEffect.SetTrigger("Hurt");
                    float dmg = Mathf.Clamp(change, health.maxHealth * 0.09f, health.maxHealth * 0.2f);
                    dmg = dmg / (health.maxHealth * 0.2f);
                    hurtEffect.SetFloat("Damage", dmg);
                }else
                {
                    Image img = hurtEffect.GetComponent<Image>();
                    hurtEffect.GetComponent<Image>().color = new Color(img.color.r, img.color.g, img.color.b, 0);
                    hurtEffect.Play("Hurt", -1, 0f);
                }

                
            }

        }

        void Respawn(int connId, uint netId)
        { 
            health = GameManager.GetInstance().localPlayer.health;
            HealthChange(0);
        }

        void Update()
        {
            UpdateHealthSlider();
            //UpdatePickupText();
        }

        /*

        void UpdatePickupText()
        {
            if (pickupText != null)
            {

                if (showPickupText) {
                    pickupText.enabled = true;
                    pickupText.text = "E to pick up: " + pickupName;
                }
                else {
                    pickupText.enabled = false;
                }
            }
        }

        */

        void UpdateHealthSlider()
        {
            if (healthSlider != null && health)
            {
                healthSlider.value = Mathf.Lerp(healthSlider.value, ((float)currentHealth) / ((float)health.maxHealth), Time.deltaTime * healthSmooth);
            }
        }

        void GameOver(int connectionId, uint netId)
        {
            if (healthSlider != null)
            {
                healthSlider.value = 0;
            }
        }

    }
}