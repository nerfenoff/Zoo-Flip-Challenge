using UnityEngine;

public class PlatformKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }
    }
}
