using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum Status
    {
        ACTIVE,
        INACTIVE
    }

    // reference to the input]
    [SerializeField] protected SO_InputTracker inputTracker;
    protected float moveDirection;

    // platform movement speed
    [SerializeField] protected float moveSpeed = 6;

    // status of the platfom
    protected Status status;

    // prevent from destruction the first time the ball is launched
    public bool IsImmune { get; protected set; }

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
