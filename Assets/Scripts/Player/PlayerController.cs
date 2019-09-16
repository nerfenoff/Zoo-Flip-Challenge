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
    public bool isMove = false;
    Rigidbody2D rb;

    float JumpForce = 1;

    private void Start()
    {
        isCanJump = true;
        rb = Player.GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        Debug.Log(isKeepForce);
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

    private void LateUpdate()
    {
        if (rb.velocity.y == 0)
        {
            isCanJump = true;
            isMove = true;
        }
        else
            isMove = false;
    }
    private void OnMouseDown()
    {

        StartCoroutine(KeepForce());

    }

    private void OnMouseUp()
    {
        isKeepForce = false;
    }

    IEnumerator KeepForce()
    {
        yield return new WaitWhile(() => !isCanJump);
        isKeepForce = true;
        rb.useAutoMass = false;
        rb.mass = 1;
        rb.gravityScale = 1f;
        while (isKeepForce)
        {
            JumpForce += ForceScale * Time.deltaTime;
            JumpForce = Mathf.Clamp(JumpForce, 1f, 2500f);
            Vector3 TargetScale = new Vector3(1f, 0.7f, 1f);
            Player.transform.localScale = Vector3.MoveTowards(Player.transform.localScale, TargetScale, 0.2f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        rb.useAutoMass = true;
        rb.gravityScale = 8f;
        rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Force);
        Player.transform.localScale = Vector3.one;
        JumpForce = 1;
        isjump = true;
        isCanJump = false;
    }
}
