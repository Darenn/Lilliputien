using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Core : MonoBehaviour {

    public delegate void OnCoreExplosionAction();
    public static event OnCoreExplosionAction OnCoreExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Percing"))
        {
            if (OnCoreExplosion != null)
                OnCoreExplosion();
        }
    }
}
