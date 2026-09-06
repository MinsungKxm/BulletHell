using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public float turnSpeed = 100.0f;
    public InputAction moveAction;
    public Vector2 moveInput;
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * speed * Time.deltaTime * moveInput.y);
        transform.Rotate(
            Vector3.up * turnSpeed * Time.deltaTime * moveInput.x
        );
    }
}
