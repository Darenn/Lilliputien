using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Animator CanvasAnimator;

    // Main Menu
    public Text Title;
    public GameObject PlayButton;
    public GameObject ExitButton;

    // In Game menu
    public Text GameOverText;
    public Image BlackFadeImage;
    public GameObject ReturnToMenuButton;
    public GameObject ContinueButton;

    public void OnGameOver()
    {

    }
}
