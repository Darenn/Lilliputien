using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOnPlanet : MonoBehaviour {

    public Rigidbody2D rb;
       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
