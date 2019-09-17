using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlatformInteract : MonoBehaviour
{
    public float minVelocity = 10f;
    public float maxVelocity = 700f;
    [HideInInspector]
    public float fallSpeed = 10f;
    public GameManager gameManager;
    [SerializeField]
    BoxCollider2D PlatformCollision;
    [SerializeField]
    BoxCollider2D PlatformTrigger;
    GameObject player;
    PlayerController PC;
    bool isMoved = false;
    bool isOnPlatform;
    bool isJump = false;
    private void Start()
    {
        PC = GetComponentInParent<PlayerController>();
        player = GameObject.Find("Player");
        minVelocity = Screen.height * (minVelocity / 100);
        maxVelocity = Screen.height * (maxVelocity / 100);
        fallSpeed = maxVelocity;
    }
    private void Update()
    {
        
        RectTransform rectTransformPlayer = (RectTransform)player.transform;
        RectTransform rectTransformPlatform = (RectTransform)transform;
        if (!isMoved)
        {
            return;
        }

        if (rectTransformPlatform.position.y + 0.4f <= rectTransformPlayer.position.y)
            isJump = true;

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
        if (collision.gameObject.tag == "Player")
            if (!isMoved && !isOnPlatform)
            {
                isMoved = true;
                Rigidbody2D rb = this.gameObject.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                collision.transform.SetParent(transform);
                gameManager.ToNextPlatform((RectTransform)transform);
                GetComponentInChildren<Text>().text = gameManager.CurrentScore.ToString();
                isOnPlatform = true;
            }
            else if (isOnPlatform && !PC.isKeepForce && !PC.isjump && isJump && !PC.isFalling)
            {
                fallSpeed = maxVelocity * 2f;
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
