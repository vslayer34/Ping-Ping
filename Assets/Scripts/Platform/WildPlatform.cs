using UnityEngine;

public class WildPlatform : Platform
{
    private void Update()
    {
        // updating the user input and handling the movement
        moveDirection = inputTracker.userInput;
        Move();
    }
}
