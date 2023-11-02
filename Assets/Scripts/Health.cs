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

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        currentHealth = currentHealth - damage;

        if(currentHealth <= 0)
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
