using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : NPCController
{
    [Header("Waypoint")]
    public Transform waypoint;
    [SerializeField]
    float waypointDistance;
    [SerializeField]
    float waypointAttackDistance;

    [Header("Attack")]
    public GameObject[] nearbyEnemies;
    private string enemiesTag = "Enemy";
    public float findResetInterval = 5.0f;
    private float findTimer = 0.0f;

    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float enemyDistance;
    [SerializeField]
    float attackDistance;

    [SerializeField]
    int attackDamage;
    public float attackResetInterval = 2.0f;
    private float attackTimer = 0.0f;

    public override void FixedUpdate()
    {
        findTimer += Time.deltaTime;
        attackTimer += Time.deltaTime;

        if (findTimer >= findResetInterval)
        {
            FindClosestEnemy();
            findTimer = 0.0f;
        }

        if (Vector2.Distance(waypoint.position, gameObject.transform.position) > waypointDistance)
        {
            target = waypoint;
            minimumRange = waypointDistance;
        }

        if (enemy != null) {
            if ((Vector2.Distance(waypoint.position, gameObject.transform.position) <= waypointAttackDistance) &&
                Vector2.Distance(enemy.transform.position, gameObject.transform.position) < enemyDistance)
            {
                target = enemy.transform;
                minimumRange = attackDistance;
                if (Vector2.Distance(enemy.transform.position, gameObject.transform.position) < attackDistance)
                {
                    Attack(enemy);
                }
            }
        }

        base.FixedUpdate();
    }

    void Attack(GameObject attackTarget)
    {
        if (attackTimer >= attackResetInterval)
        {
            attackTarget.GetComponent<Health>().TakeDamage(attackDamage);
            attackTimer = 0.0f;
        }
    }

    void FindClosestEnemy()
    {
        nearbyEnemies = GameObject.FindGameObjectsWithTag(enemiesTag);

        GameObject closestEnemy = null;
        float minDistance = float.MaxValue;
        foreach (GameObject entity in nearbyEnemies)
        {
            // Calculate the distance to the current enemy
            float distanceToEnemy = Vector3.Distance(transform.position, entity.transform.position);

            // Check if this enemy is closer than the current closest enemy
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                closestEnemy = entity;
            }
        }

        if (closestEnemy != null)
        {
            enemy = closestEnemy;
        }
    }
}
