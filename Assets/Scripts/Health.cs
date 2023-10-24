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

    public SoulIcon soulIcon;

    void Start()
    {
        currentHealth = maxHealth;

        if(gameObject.tag == "Enemy")
        {
            GameObject soulIconObject = GameObject.FindWithTag("SoulIcon");
            if(soulIconObject != null)
            soulIcon = soulIconObject.GetComponent<SoulIcon>();
        }
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
            soulIcon.EnemyKilled();
        }
        Destroy(gameObject);
    }
}
