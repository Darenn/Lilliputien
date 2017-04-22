using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public int HP;
    public SpriteRenderer[] weakZones;
    public Color good;
    public Color outch;

    private void Awake()
    {
        good = weakZones[0].color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (SpriteRenderer sp in weakZones)
                sp.color = outch;
            StartCoroutine(rePutBlue());
            Debug.Log("bla");
            HP--;
            if (HP <= 0)
            {
                Destroy(gameObject);

            }
        }
    }

    IEnumerator rePutBlue()
    {
        yield return new WaitForSeconds(.5f);
        foreach (SpriteRenderer sp in weakZones)
            sp.color = good;
    }
}
