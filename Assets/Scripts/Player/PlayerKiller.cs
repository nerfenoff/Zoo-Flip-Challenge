using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public static bool isAlive;

    private void Awake()
    {
        isAlive = true;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.transform.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
    //        isAlive = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            isAlive = false;
        }
    }
}
