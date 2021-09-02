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
	private Rigidbody2D rb;
	private CharStats charStats;
	private PlayerDirection playerDirection;

	private LayerMask damageableLayerMask;

	private Vector2 rawMovementVector;
	private float attackCoolDown = 0;

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		rb = GetComponent<Rigidbody2D>();
		playerInput = GetComponent<PlayerInput>();
		playerDirection = GetComponent<PlayerDirection>();
		damageableLayerMask = LayerMask.GetMask("Damageable");
	}

	private void Start()
	{
		playerSpeed = charStats.getSpeed();
	}

	private void Update()
	{
		// Basic Attack cooldown
		// TODO: generalizar cooldown?
		attackCoolDown -= Time.deltaTime;
		if (attackCoolDown < 0)
			attackCoolDown = 0;
	}

	private void FixedUpdate()
	{
		// Limita a magnitude do vetor de movimento a 1, para evitar que movimentos na diagonal sejam mais rapidos
		Vector2 movementVector = Vector2.ClampMagnitude(rawMovementVector, 1);

		// Escala o vetor de acordo com a velocidade do player e o tempo desde o ultimo frame
		movementVector *= playerSpeed * Time.fixedDeltaTime;

		// Aplica a movimentacao
		rb.MovePosition(rb.position + movementVector);

		// Faz player olhar para o mouse
		playerDirection.LookAtMouse();
	}

	/// Evento ativado pelo InputSystem para movimentacao
	public void onMovement(InputAction.CallbackContext value)
	{
		// Le o vetor de movimento bruto passado pelo InputSystem
		rawMovementVector = value.ReadValue<Vector2>();
	}

	/// Evento ativado pelo InputSystem para ataques basicos
	public void onAttack(InputAction.CallbackContext value)
	{
		// TODO: basear em stats dos personagens?
		float attackSpread = 0.5f;
		float attackRange = 0.5f;

		// Cancelar ataque se estiver em cooldown, caso ao contrario definir para 1s
		if (attackCoolDown > 0) return;
		attackCoolDown = 1.0f;

		// Calcula o ponto de ataque, em frente do personagem
		Vector3 attackLocation = transform.position;
		attackLocation += transform.right * attackRange; // Em 2D, no eixo usado, "frete" eh transform.right

		// Lista de objetos dentro do range de ataque
		Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation, attackSpread, damageableLayerMask);

		// Ataca os objetos atacaveis detectados.
		// TODO: Fazer implementacao generica de objetos atacaveis
		foreach (var item in damage) {
			DummyController dummy = item.GetComponent<DummyController>();
			if (dummy) {
				dummy.ApplyDamage(charStats.getDamage());
			}
		}

	}

}
