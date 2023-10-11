using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public PlayerMovement player;
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField]
    public float bulletForce;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the firePoint to the mouse position
        Vector2 direction = (mousePosition - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}
