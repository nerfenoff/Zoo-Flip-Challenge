using UnityEngine;

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
        GetComponent<PlayerController>().isKeepForce = false;
    }

    private void Update()
    {
        if (!PlayerController.isAlive)
            restartButton.SetActive(true);
    }


}
