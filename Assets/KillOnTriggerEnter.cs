using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTriggerEnter : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Killable o = collision.GetComponent<Killable>();
        if (o != null)
            o.Kill();
    }
}
