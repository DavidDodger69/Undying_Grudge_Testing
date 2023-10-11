using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Spell : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
