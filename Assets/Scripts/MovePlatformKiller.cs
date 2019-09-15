using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Debug.Log(transform.localPosition);
            Debug.Log(transform.position);
            transform.localPosition = new Vector3(0f, -((RectTransform)transform).rect.height/2, 0f);
            Destroy(this);
        }
    }
}
