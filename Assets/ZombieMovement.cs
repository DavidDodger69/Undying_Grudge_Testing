using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : NPCMovement
{
    [SerializeField]
    public Transform target;
    // Update is called once per frame

    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", target.position.x - transform.position.x);
        animator.SetFloat("Vertical", target.position.y - transform.position.y);
        animator.SetFloat("Speed", (target.position-transform.position).sqrMagnitude);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
