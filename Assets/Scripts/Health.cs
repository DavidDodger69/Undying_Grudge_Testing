using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    public int maxHealth;

    [SerializeField]
    private GameObject gravePrefab;

    public PlayerMovement player;

    public bool is_tutorial_NPC = false;
    public bool tutorial_NPC_Died = false;
    public bool is_player = false;
    public bool is_paladin = false;

    [Header("Player")]
    public HealthBar healthbar;

    [Header("Paladin")]
    public GameObject victory;

    void Start()
    {
        currentHealth = maxHealth;
        if (is_player || is_paladin)
        {
            healthbar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        if (is_player || is_paladin)
        {
            healthbar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            if (!is_paladin)
            {
                if (is_tutorial_NPC)
                {
                    tutorial_NPC_Died = true;
                }
                Instantiate(gravePrefab, gameObject.transform.position, gameObject.transform.rotation);
            } else if(is_paladin)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "numberOfHeals", player.GetComponent<Spells>().number_of_Heals },
                    { "numberOfShots", player.GetComponent<Spells>().number_of_Shots },
                    { "numberOfSkeletons", player.GetComponent<Spells>().number_of_Animates },
                    { "paladinAliveTimer", player.paladinCounter },
                };

                AnalyticsService.Instance.CustomData("GameEnded", parameters);
                AnalyticsService.Instance.Flush();
                victory.SetActive(true);
            }
        } else
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "numberOfHeals", player.GetComponent<Spells>().number_of_Heals },
                    { "numberOfShots", player.GetComponent<Spells>().number_of_Shots },
                    { "numberOfSkeletons", player.GetComponent<Spells>().number_of_Animates },
                    { "paladinAliveTimer", player.paladinCounter },
                };

            AnalyticsService.Instance.CustomData("GameEnded", parameters);
            AnalyticsService.Instance.Flush();
        }
        Destroy(gameObject);
    }

    public void Heal(int healing)
    {
        currentHealth += healing;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (is_player || is_paladin)
        {
            healthbar.SetHealth(currentHealth);
        }
    }
}
