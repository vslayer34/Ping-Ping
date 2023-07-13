using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    [SerializeField] Platform parentPlatform;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (parentPlatform.IsImmune)
        {
            
            Debug.Log(parentPlatform.IsImmune);
            return;
        }
            Destroy(gameObject, 1.0f);
    }
}
