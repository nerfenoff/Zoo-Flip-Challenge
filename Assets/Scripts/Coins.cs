using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        if(Random.Range(0,2) == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ++gameManager.coins;
            Destroy(gameObject);
        }
    }
}
