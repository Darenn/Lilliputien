using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour {

    public SpriteRenderer[] sp;

	public void Kill()
    {
        /*foreach(Component c in GetComponentsInChildren<Component>())
        {
            if (!new List<Component>(sp).Contains(c) && c != this)
            {
                Destroy(c);
            }
        }*/
        Destroy(gameObject);
    }
}
