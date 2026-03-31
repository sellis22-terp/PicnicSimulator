using UnityEngine;
using UnityEngine.InputSystem; // Ensure you have the Input System package installed

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 720f; // Degrees per second

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Character characters usually don't roll, so freeze rotation on X and Z
        rb.freezeRotation = true;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        // 1. Convert raw input into a movement vector
        Vector3 inputDirection = new Vector3(movementX, 0.0f, movementY);

        // 2. FIX: Transform the direction from 'World Space' to 'Local Space'
        // This makes (0, 0, 1) move towards the character's front, not World North.
        Vector3 moveDirection = transform.TransformDirection(inputDirection);

        // 3. Apply velocity based on the NEW relative direction
        Vector3 targetVelocity = moveDirection * speed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);

    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            Debug.Log("item");
        }
    }
}