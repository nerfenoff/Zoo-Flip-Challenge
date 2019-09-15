using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            PlatformInteract platformInteract = collision.gameObject.GetComponent<PlatformInteract>();
            if (platformInteract)
                platformInteract.fallSpeed = 30f;
        }
    }
}
