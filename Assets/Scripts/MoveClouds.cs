using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    public float speed;
    Vector3 moveTo;
    int direction;
    bool isVivible;
    void Start()
    {
        direction = (transform.localPosition.x < 0 ? 1 : -1);
        moveTo = new Vector3(Screen.width * direction, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveTo, speed * Time.deltaTime);
        if (direction > 0)
        {
            if (transform.localPosition.x >= moveTo.x)
                Destroy(gameObject);
        }
        else
        {
            if (transform.localPosition.x <= moveTo.x)
                Destroy(gameObject);
        }

    }


}
