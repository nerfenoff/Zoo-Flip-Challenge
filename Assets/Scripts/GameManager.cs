using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RectTransform spawnZone;
    public GameObject platformToSpawn;

    public Text ScoreText;
    public Text CoinsText;

    public int maxScore = 0;
    public int CurrentScore = 0;
    public int coins = 0;
    RectTransform platform;

    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");
        coins = PlayerPrefs.GetInt("Coins");
        ScoreText.text = maxScore.ToString();
        CoinsText.text = coins.ToString();
    }
    private void FixedUpdate()
    {
        CoinsText.text = coins.ToString();
        if(!PlayerKiller.isAlive)
        {
            if (CurrentScore > maxScore)
            {
                maxScore = CurrentScore;
                PlayerPrefs.SetInt("MaxScore", maxScore);
            }
            ScoreText.text = maxScore.ToString();
            PlayerPrefs.SetInt("Coins", coins);
            SceneManager.LoadScene(0);
        }
    }
    public void ToNextPlatform(RectTransform previos)
    {
        platform = previos;
        CurrentScore += 1;
        RectTransform newPlatform = (RectTransform)Instantiate<GameObject>(platformToSpawn, (RectTransform)spawnZone.parent).transform;
        newPlatform.localPosition = new Vector3(0f, Screen.width, 0f);
        newPlatform.GetComponent<PlatformInteract>().gameManager = this;
        newPlatform.ForceUpdateRectTransforms();
        StartCoroutine(MoveToPoint(newPlatform));
    }

    IEnumerator MoveToPoint(RectTransform newPlatformTransform)
    {
        Vector3 point = new Vector3(0f, spawnZone.localPosition.y + Random.Range(0f,spawnZone.rect.y), 0f);

        while(newPlatformTransform.localPosition.y > point.y)
        {
            newPlatformTransform.localPosition = Vector3.MoveTowards(newPlatformTransform.localPosition, point, 700f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        platform.SetParent(newPlatformTransform);
    }
}
