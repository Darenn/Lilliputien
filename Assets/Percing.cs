using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Percing : MonoBehaviour { 

    public float SizeToReachCore = 1.6F;

    private bool toDig = false;
    private bool toUnearth = false;
    private float speedPerSeconds;
    private float baseScale;
    private Vector3 basePosition;

    private void Awake()
    {
        baseScale = transform.localScale.y;
        basePosition = transform.position;
    }

    public void Dig(float timeToReachCore)
    {
        toDig = true;
        this.speedPerSeconds = (SizeToReachCore - baseScale) / timeToReachCore;
    }

    public void Unearth(float timeToReachCore)
    {
        toUnearth = true;
        this.speedPerSeconds = (SizeToReachCore - baseScale) / timeToReachCore;
    }

    private void Update()
    {
        // Dig has priority on unearth
        if (toDig)
        {
            transform.localScale += new Vector3(0, speedPerSeconds * Time.deltaTime);
            transform.position = basePosition - transform.up * ((transform.localScale.y - baseScale));
        } else if (toUnearth)
        {
            transform.localScale -= new Vector3(0, speedPerSeconds * Time.deltaTime);
            transform.position = basePosition - transform.up * ((transform.localScale.y - baseScale));
        }
        toDig = false;
        toUnearth = false;
    }
}
