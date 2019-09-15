using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RectTransform spawnZone;
    public GameObject platformToSpawn;
    RectTransform platform;
    public int score;

    public void ToNextPlatform(RectTransform previos)
    {
        platform = previos;
        score += 1;
        RectTransform newPlatform = (RectTransform)Instantiate<GameObject>(platformToSpawn, (RectTransform)transform).transform;
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
        platform.parent = newPlatformTransform;
    }
}
