using UnityEngine;
using UnityEngine.InputSystem;

public class GetInputs : MonoBehaviour
{
    public Vector2 move { get; private set; }
    public bool sprint;

    private void OnMove(InputValue inputValue)
    {
        move = inputValue.Get<Vector2>();
    }

    private void OnSprint(InputValue inputValue)
    {
        sprint = inputValue.isPressed;
    }
}
