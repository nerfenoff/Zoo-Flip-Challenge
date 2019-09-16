using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float ForceScale = 8f;
    [HideInInspector]
    public bool isCanJump = true;
    [HideInInspector]
    public bool isFalling = false;
    [HideInInspector]
    public bool isjump = false;
    [HideInInspector]
    public bool isKeepForce = false;
    Rigidbody2D rb;
    SoundManager soundManager;
    float JumpForce = 1;

    private void Start()
    {
        isCanJump = true;
        rb = Player.GetComponent<Rigidbody2D>();
        soundManager = GetComponent<GameManager>().soundManager;
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
            StartCoroutine(AvalibaleJumping());
            isFalling = true;
            isjump = false;
        }

    }

    private void OnMouseDown()
    {

        StartCoroutine(KeepForce());

    }

    private void OnMouseUp()
    {
        isKeepForce = false;
    }

    IEnumerator AvalibaleJumping()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitWhile(() => rb.velocity.y != 0);
        isCanJump = true;
    }
    IEnumerator KeepForce()
    {
        yield return new WaitWhile(() => !isCanJump);
        isKeepForce = true;
        
        rb.gravityScale = 1f;
        while (isKeepForce)
        {
            JumpForce += ForceScale * Time.deltaTime;
            JumpForce = Mathf.Clamp(JumpForce, 1f, 50f);
            Vector3 TargetScale = new Vector3(1f, 0.7f, 1f);
            Player.transform.localScale = Vector3.MoveTowards(Player.transform.localScale, TargetScale, 0.25f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        rb.gravityScale = 8f;
        isjump = true;
        soundManager.Jump();
        rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        Player.transform.localScale = Vector3.one;
        JumpForce = 1;
        
        isCanJump = false;
    }
}
