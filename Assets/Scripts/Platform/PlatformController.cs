using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform holdingArea;         // referance to the holding area
    [SerializeField] private Transform ballPrefab;                // referance to the ballprefab
    
    // reference to the input]
    [SerializeField] private SO_InputTracker inputTracker;
    private float moveDirection;

    // platform movement speed
    [SerializeField] private float moveSpeed = 6;

    // the spawned ball transform and rigidbody2d referances
    private Transform spawnedBall;
    private Rigidbody2D spawnedBallRb;


    private void Start()
    {
        inputTracker.OnShoot += ShootBall;
        SetUpTheBall();
    }

    private void Update()
    {
        // updating the user input and handling the movement
        moveDirection = inputTracker.userInput;
        Move();
    }

    //----------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Move the platform
    /// </summary>
    private void Move()
    {
        Vector3 moveVector = new Vector3(0.0f, moveDirection, 0.0f);

        transform.position += moveVector * Time.deltaTime * moveSpeed;
    }

    /// <summary>
    /// Shoot the ball when the player hit space
    /// </summary>
    private void ShootBall()
    {
        Debug.Log("Shooting");
    }

    /// <summary>
    /// Create the ball at the start of the game
    /// </summary>
    private void SetUpTheBall()
    {
        // spawn the ball and set its rigidbody to static temperaray
        spawnedBall = Instantiate(ballPrefab, holdingArea);
        spawnedBall.localPosition = Vector3.zero;
        spawnedBallRb = spawnedBall.GetComponent<Rigidbody2D>();
        spawnedBallRb.bodyType = RigidbodyType2D.Static;
    }

    private void OnDisable()
    {
        inputTracker.OnShoot -= ShootBall;
    }
}
