using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Increase the ball velocity by 1% each collision
        rb.velocity *= 1.01f;
    }
}
