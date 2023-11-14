using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField]
    private Camera mainCamera;
    public Vector2 mouseWorldPos;

    public Vector2 lookDir;
    public float angle;

    Vector2 movement;

    [Header("Testing")]
    [SerializeField] GameObject Paladin;
    public int paladinCounter;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        animator.SetFloat("Horizontal", lookDir.x);
        animator.SetFloat("Vertical", lookDir.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        paladinCounter = Paladin.GetComponent<PaladinController>().bossFightTimeCounter;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        lookDir = mouseWorldPos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }
}
