using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI    ;

public class CloudsController : MonoBehaviour
{
    public Sprite[] clouds;
    public GameObject[] cloudsTemplates;

    private void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    void StpawNew()
    {
        StartCoroutine(SpawnCloud());
    }
    IEnumerator SpawnCloud()
    {
        GameObject cloud = Instantiate<GameObject>(cloudsTemplates[Random.Range(0, cloudsTemplates.Length)], transform);
        cloud.GetComponent<Image>().sprite = clouds[Random.Range(0, clouds.Length)];
        int side = (Random.Range(-1, 1) >= 0 ? 1 : -1);
        float yPos = Random.Range(((RectTransform)transform).rect.height / 2  * -1, ((RectTransform)transform).rect.height / 2);
        cloud.transform.localPosition = new Vector3(Screen.width  * side, yPos, 0f);
        yield return new WaitForSeconds(Random.Range(4, 10));
        StartCoroutine(SpawnCloud());
    }
}
