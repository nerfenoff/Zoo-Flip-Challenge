using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float ForceScale = 8f;
    [HideInInspector]
    public bool isFalling = false;


    float JumpForce = 1;
    bool isjump = false;
    bool isKeepForce = false;
    Rigidbody2D rb;


    private void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isjump)
        {
            isFalling = false;
            return;
        }
        
        if(!isFalling && rb.velocity.y <= 0)
        {
            isFalling = true;
            isjump = false;
        }

    }
    private void OnMouseDown()
    {
        isKeepForce = true;
        StartCoroutine(KeepForce());
    }

    private void OnMouseUp()
    {
        isKeepForce = false;
    }

    IEnumerator KeepForce()
    {
        while(isKeepForce)
        {
            JumpForce += ForceScale * Time.deltaTime;
            JumpForce = Mathf.Clamp(JumpForce, 1f, 13f);
            Vector3 TargetScale = new Vector3(1f, 0.7f, 1f);
            Player.transform.localScale = Vector3.MoveTowards(Player.transform.localScale, TargetScale, 0.2f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        Player.transform.localScale = Vector3.one;
        JumpForce = 1;
        isjump = true;
    }
}
