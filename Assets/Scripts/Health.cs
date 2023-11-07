using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    public int maxHealth;

    [SerializeField]
    private GameObject gravePrefab;

    public bool is_tutorial_NPC = false;
    public bool tutorial_NPC_Died = false;
    public bool is_player = false;

    public HealthBar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        if (is_player)
        {
            healthbar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        if (is_player)
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
            if (is_tutorial_NPC)
            {
                tutorial_NPC_Died = true;
            }
            Instantiate(gravePrefab, gameObject.transform.position, gameObject.transform.rotation); 
        }
        Destroy(gameObject);
    }
}
