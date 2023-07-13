using UnityEngine;

public class Platform : MonoBehaviour
{
    // reference to the input]
    [SerializeField] protected SO_InputTracker inputTracker;
    protected float moveDirection;

    // platform movement speed
    [SerializeField] protected float moveSpeed = 6;

    //---------------------------------------------------------------------------------------------

    // methods
    /// <summary>
    /// Move the platform
    /// </summary>
    protected void Move()
    {
        Vector3 moveVector = new Vector3(0.0f, moveDirection, 0.0f);

        transform.position += moveVector * Time.deltaTime * moveSpeed;
    }
}
