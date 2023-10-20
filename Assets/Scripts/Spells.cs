using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public PlayerMovement player;
    public Transform firePoint;

    [Header("Prefabs")]
    public GameObject bulletPrefab;
    public GameObject zombiePrefab;
    public GameObject target1Prefab;

    [SerializeField]
    public float bulletForce;

    [Header("Cooldowns")]
    [SerializeField]
    private int basic_spell_cooldown;
    [SerializeField]
    private int basic_spell_cooldown_reset;

    [SerializeField]
    private bool onGrave = false;
    [SerializeField]
    private GameObject graveGameobject;

    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetButtonDown("Jump"))
        {
            AnimateDead();
            Destroy(graveGameobject);
        }
    }

    private void FixedUpdate()
    {
        if (basic_spell_cooldown > 0)
        {
            basic_spell_cooldown--;
        }
    }

    void Shoot()
    {
        if (basic_spell_cooldown == 0)
        {
            BasicSpell();
            basic_spell_cooldown = basic_spell_cooldown_reset;
        }
    }

    void BasicSpell()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the firePoint to the mouse position
        Vector2 direction = (mousePosition - firePoint.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullet"), LayerMask.NameToLayer("Allies"));
        rb.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }

    void AnimateDead()
    {
        GameObject newZombie = Instantiate(zombiePrefab, graveGameobject.transform.position, graveGameobject.transform.rotation);
        newZombie.GetComponent<ZombieController>().waypoint = target1Prefab.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grave")
            onGrave = true;
            graveGameobject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grave")
            onGrave = false;
            graveGameobject = null;
    }
}
