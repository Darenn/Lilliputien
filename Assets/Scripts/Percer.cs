using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Percer : MonoBehaviour {

    public GameObject PercingPrefab;
    public float TimeToReachCore;

    GameObject percing;
    float timer = 0;
	
	void Update () {
        if (percing)
        {
            percing.GetComponent<Percing>().Dig(TimeToReachCore);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            percing = Instantiate(PercingPrefab, transform.position, transform.rotation);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
