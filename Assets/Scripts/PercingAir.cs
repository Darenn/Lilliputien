using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PercingAir : MonoBehaviour {

    public float SizeToReachCore = 1.6F;
    public GameObject Digger;

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
        if (baseScale >= transform.localScale.y)
        {
            Destroy(gameObject);
        }
        else
        {
            toUnearth = true;
            this.speedPerSeconds = (SizeToReachCore - baseScale) / timeToReachCore;
        }
    }

    private void Update()
    {
        // unearth has priority on dig

        if (toUnearth)
        {
            transform.localScale -= new Vector3(0, speedPerSeconds * Time.deltaTime);

            transform.position -= transform.up * (speedPerSeconds * Time.deltaTime);
            if (Digger != null) 
                Digger.transform.position -= transform.up * (speedPerSeconds *1.6f * Time.deltaTime);
            else
            {
                Destroy(gameObject);
            }
        }
        else if (toDig)
        {
            transform.localScale += new Vector3(0, speedPerSeconds * Time.deltaTime);
            transform.position -= transform.up * (speedPerSeconds * Time.deltaTime);
            //transform.position = basePosition - transform.up * ((transform.localScale.y - baseScale));
        }
        toDig = false;
        toUnearth = false;
    }
}
