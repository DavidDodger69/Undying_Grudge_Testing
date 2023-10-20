using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : NPCController
{
    [SerializeField]
    public Transform waypoint;
    [SerializeField]
    float distance;

    public override void FixedUpdate()
    {
        target = waypoint;
        minimumRange = distance;

        base.FixedUpdate();
    }
}
