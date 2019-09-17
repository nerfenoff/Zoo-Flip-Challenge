using UnityEngine;

public class MovePlatformKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            transform.localPosition = new Vector3(0f, -((RectTransform)transform).rect.height/2, 0f);
            Destroy(this);
        }
    }
}
