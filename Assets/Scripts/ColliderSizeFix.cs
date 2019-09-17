using UnityEngine;

public class ColliderSizeFix : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D collider2d = null;
    [SerializeField]
    BoxCollider collider = null;

    private void Start()
    {
        if (collider2d)
        {

            Vector2 rect = collider2d.size;
            collider2d.size = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
            if (collider2d.offset != Vector2.zero)
            {
                Vector2 offset = collider2d.size - rect;
                offset.x = 0;
                collider2d.offset += offset;
            }
        }
        if(collider)
            collider.size = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
    }
}
