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
            Instantiate(gravePrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);
    }
}
