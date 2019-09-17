using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            PlayerController.isAlive = false;           
        }
    }
}
