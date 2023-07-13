using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    [SerializeField] Platform parentPlatform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!parentPlatform.IsImmune)
            Destroy(gameObject, 1.0f);
    }
}
