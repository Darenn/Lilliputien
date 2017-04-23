using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public delegate void StartAction();
    public static event StartAction OnStartGame;

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

    public void OnEnable()
    {
        GameManager.OnGameLost += OnGameOver;
    }

    public void OnGameOver()
    {
        CanvasAnimator.SetTrigger("GameOver");
    }

    public void StartGame()
    {
        CanvasAnimator.SetTrigger("StartGame");
        OnStartGame();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
