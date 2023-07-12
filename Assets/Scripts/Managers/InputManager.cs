using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // referance the PlayerInputAction
    private PlayerAction playerAction;
    [SerializeField] private SO_InputTracker inputTracker;
    

    // safe the user input
    public float UserInput { get; private set; }

    private void Awake()
    {
        playerAction = new PlayerAction();
    }

    private void Start()
    {
        // enable the PlayerInputAction and subscribe to the shoot even
        playerAction.Player.Enable();
        playerAction.Player.Shoot.performed += Shoot_performed;
    }


    // invoke the shooting action
    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnShoot?.Invoke();
    }

    private void Update()
    {
        // getting the user input and updating the input tracker of that
        UserInput = playerAction.Player.Move.ReadValue<float>();
        inputTracker.userInput = UserInput;
    }

    private void OnDisable()
    {
        // Unsubscribe to the shoot performed
        playerAction.Player.Shoot.performed -= Shoot_performed;
    }
}
