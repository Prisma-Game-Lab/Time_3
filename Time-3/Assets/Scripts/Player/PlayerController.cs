using UnityEngine;
using UnityEngine.InputSystem;

//Usar RequireComponent para adicionar componentes automaticamente ao jogador -Arthur
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharStats))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private float playerSpeed;

	private PlayerInput playerInput;
	private Vector2 rawMovementVector;
	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		playerInput = GetComponent<PlayerInput>();
	}

	private void FixedUpdate()
	{
		playerSpeed = GetComponent<CharStats>().getSpeed();
		// Limita a magnitude do vetor de movimento a 1, para evitar que movimentos na diagonal sejam mais rapidos
		Vector2 movementVector = Vector2.ClampMagnitude(rawMovementVector, 1);
		// Escala o vetor de acordo com a velocidade do player e o tempo desde o ultimo frame
		movementVector *= playerSpeed * Time.fixedDeltaTime;
		// Aplica a movimentacao
		rb.MovePosition(rb.position + movementVector);
		
	}

	// Evento ativado pelo InputSystem para movimentacao
	public void onMovement(InputAction.CallbackContext value)
	{
		// Le o vetor de movimento bruto passado pelo InputSystem
		rawMovementVector = value.ReadValue<Vector2>();
	}

}
