﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledOnTrigger : MonoBehaviour {

    public Killable ObjectToKill;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ObjectToKill.Kill();
        }
    }
}
