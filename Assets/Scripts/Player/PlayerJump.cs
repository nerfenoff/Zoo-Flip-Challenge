using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    PlayerController PC;

    private void Start()
    {
        PC = GetComponentInParent<PlayerController>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //PC.isCanJump = true;
    }
}
