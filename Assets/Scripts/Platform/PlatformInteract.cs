using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformInteract : MonoBehaviour
{

    public float fallSpeed  = 10;
    public GameManager gameManager;
    [SerializeField]
    BoxCollider2D PlatformCollision;
    [SerializeField]
    BoxCollider2D PlatformTrigger;

    PlayerController PC;
    bool isMoved = false;
    private void Start()
    {
        //Debug.Log(transform.parent.transform.parent.name);
        PC = transform.parent.transform.parent.GetComponent<PlayerController>();

    }
    private void Update()
    {
        if (!isMoved)
            return;
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, -Screen.height, 0), fallSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(FallPlatform());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMoved && collision.gameObject.tag == "Player")
        {
            isMoved = true;
            Rigidbody2D rb = this.gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            collision.transform.SetParent(transform);
            gameManager.ToNextPlatform((RectTransform)transform);
            GetComponentInChildren<Text>().text = gameManager.CurrentScore.ToString();
        }
    }

    IEnumerator FallPlatform()
    {
        yield return new WaitWhile(() => !PC.isFalling);
        PlatformCollision.enabled = true;
        Destroy(PlatformTrigger);
        PC.isFalling = false;
    }
}
