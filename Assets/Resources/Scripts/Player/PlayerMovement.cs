using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    float horizontalMovement;
    float verticalMovement;


    private void Update()
    {
        rb2d.linearVelocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        verticalMovement = context.ReadValue<Vector2>().y;
    }
}
