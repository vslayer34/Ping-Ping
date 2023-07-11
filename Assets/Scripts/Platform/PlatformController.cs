using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // reference to the input
    [SerializeField] private SO_InputTracker inputTracker;
    private float moveDirection;

    [SerializeField] private float moveSpeed = 6;

    private void Update()
    {
        // updating the user input and handling the movement
        moveDirection = inputTracker.userInput;
        Move();
    }


    /// <summary>
    /// Move the platform
    /// </summary>
    private void Move()
    {
        Vector3 moveVector = new Vector3(0.0f, moveDirection, 0.0f);

        transform.position += moveVector * Time.deltaTime * moveSpeed;
    }
}
