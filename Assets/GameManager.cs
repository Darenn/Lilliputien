using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public delegate void OnGameLostAction();
    public static event OnGameLostAction OnGameLost;

    private void onGameLost()
    {
        if (OnGameLost != null)
            OnGameLost();
    }

    private void OnEnable()
    {
        Core.OnCoreExplosion += onGameLost;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
