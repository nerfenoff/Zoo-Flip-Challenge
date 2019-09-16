﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformInteract : MonoBehaviour
{

    public float fallSpeed  = 10;
    public GameManager gameManager;
    [SerializeField]
    BoxCollider2D[] PlatformCollision;
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
                fallSpeed = 1400f;
            }

    }

    IEnumerator FallPlatform()
    {      
        yield return new WaitWhile(() => !PC.isFalling);
        foreach (Collider2D collider in PlatformCollision)
            collider.enabled = true;
        Destroy(PlatformTrigger);
        PC.isFalling = false;
    }
}
