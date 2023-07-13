using UnityEngine;

public class MainPlatform : Platform
{
    [SerializeField] private Transform holdingArea;               // referance to the holding area
    [SerializeField] private Transform ballPrefab;                // referance to the ballprefab

    // the spawned ball transform and rigidbody2d referances
    private Transform spawnedBall;
    private Rigidbody2D spawnedBallRb;

    private void Start()
    {
        inputTracker.OnShoot += ShootBall;
        SetUpTheBall();
        IsImmune = true;
    }

    private void Update()
    {
        if (status == Status.ACTIVE)
        {
            // updating the user input and handling the movement
            moveDirection = inputTracker.userInput;
            Move();
        }
    }

    //----------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Shoot the ball when the player hit space
    /// </summary>
    private void ShootBall()
    {
        // vector direction for the force and force magnitude
        float forceDirectionX = 1.0f;
        float forceDirectionY = 1.7f;
        float launchForce = 10.0f;

        // check if the platform has a ball or not
        if (holdingArea.childCount != 0)
        {
            // change the body type of the ball and release it from holding area
            spawnedBall.parent = null;
            spawnedBallRb.bodyType = RigidbodyType2D.Dynamic;

            // add shooting force to the ball
            Vector2 forceVector = new Vector2(forceDirectionX, Random.Range(-forceDirectionY, forceDirectionY));
            spawnedBallRb.AddForce(forceVector.normalized * launchForce, ForceMode2D.Impulse);
        }
        else
        {
            // there is no ball to shoot
            return;
        }

        status = Status.INACTIVE;
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
