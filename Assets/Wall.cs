using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public int HP;
    public SpriteRenderer[] weakZones;
    public Color good;
    public Color outch;
    private bool invicible = false;

    private void Awake()
    {
        good = weakZones[0].color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !invicible)
        {
            invicible = true;
            foreach (SpriteRenderer sp in weakZones)
                sp.color = outch;
            StartCoroutine(rePutBlue());
            HP--;
            if (HP <= 0)
            {
                Destroy(transform.parent.gameObject);

            }
        }
    }

    IEnumerator rePutBlue()
    {
        yield return new WaitForSeconds(.5f);
        /*foreach (SpriteRenderer sp in weakZones)
            sp.color = good;*/
        invicible = false;
    }
}
