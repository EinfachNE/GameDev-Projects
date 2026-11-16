using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    public PlayerInputActions GetPlayerInputActions()
    {
        return inputActions;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
