using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            collision.gameObject.GetComponent<PlatformInteract>().fallSpeed = 30f;
        }
    }
}
