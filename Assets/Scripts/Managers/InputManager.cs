using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerAction playerAction;
    [SerializeField] private SO_InputTracker inputTracker;
    
    public float UserInput { get; private set; }

    private void Awake()
    {
        playerAction = new PlayerAction();
    }

    private void Start()
    {
        playerAction.Player.Enable();
    }


    private void Update()
    {
        // getting the user input and updating the input tracker of that
        UserInput = playerAction.Player.Move.ReadValue<float>();
        inputTracker.userInput = UserInput;
    }
}
