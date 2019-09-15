using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject titleScreen;
    public Text ScoreText;
    public Text CoinsText;

    private void OnMouseDown()
    {
        if (titleScreen.activeSelf)
            titleScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        ScoreText.text = gameManager.CurrentScore.ToString();
    }
}
