using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;


    [SerializeField]
    public Transform target;
    [SerializeField]
    public float minimumRange;


    public virtual void FixedUpdate()
    {

        Movement(target, minimumRange);
    }

    void Movement(Transform currentTarget, float inRange)
    {
        //If the NPC is not within the range give then the NPC will walk there.
        if (Vector2.Distance(currentTarget.position, gameObject.transform.position) > inRange)
        {
            animator.SetFloat("Horizontal", currentTarget.position.x - transform.position.x);
            animator.SetFloat("Vertical", currentTarget.position.y - transform.position.y);
            animator.SetFloat("Speed", (currentTarget.position - transform.position).sqrMagnitude);

            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}
