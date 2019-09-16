using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSizeFix : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D collider2d = null;
    [SerializeField]
    BoxCollider collider = null;

    private void Start()
    {
        if(collider2d)
            collider2d.size = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
        if(collider)
            collider.size = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
    }
}
