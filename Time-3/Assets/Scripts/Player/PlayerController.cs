using UnityEngine;
using UnityEngine.InputSystem;

//Usar RequireComponent para adicionar componentes automaticamente ao jogador -Arthur
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharStats))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private PlayerInput playerInput;
	[SerializeField] private float playerSpeed;

	private Vector2 rawMovementVector;
	private Rigidbody2D rb;	

	private void Start() 
	{
		rb = GetComponent<Rigidbody2D>();
		playerInput = GetComponent<PlayerInput>();
		playerSpeed = GetComponent<CharStats>().getSpeed();
	}

	private void FixedUpdate() 
	{
		Vector2 movementVector = Vector2.ClampMagnitude(rawMovementVector, 1);
		movementVector *= playerSpeed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + movementVector);
	}

	public void onMovement(InputAction.CallbackContext value) 
	{
		rawMovementVector = value.ReadValue<Vector2>();
	}

}
