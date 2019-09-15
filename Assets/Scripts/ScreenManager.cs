using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject titleScreen;

    private void OnMouseDown()
    {
        if (titleScreen.activeSelf)
            titleScreen.SetActive(false);
    }

}
