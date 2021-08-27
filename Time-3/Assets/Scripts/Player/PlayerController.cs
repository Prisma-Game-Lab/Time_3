using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private PlayerInput playerInput;
	[SerializeField] private float playerSpeed = 1.0f;

	private Vector2 rawMovementVector;
	private Rigidbody2D rb;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		Vector2 movementVector = Vector2.ClampMagnitude(rawMovementVector, 1);
		movementVector *= playerSpeed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + movementVector);
	}

	public void onMovement(InputAction.CallbackContext value) {
		rawMovementVector = value.ReadValue<Vector2>();
	}

}
