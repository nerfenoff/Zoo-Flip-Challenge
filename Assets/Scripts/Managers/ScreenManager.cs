using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject titleScreen;
    public GameObject restartButton;

    private void OnMouseDown()
    {
        if (titleScreen.activeSelf)
            titleScreen.SetActive(false);
    }
    private void OnMouseUp()
    {
        
    }

    private void Update()
    {
        if (!PlayerKiller.isAlive)
            restartButton.SetActive(true);
    }


}
