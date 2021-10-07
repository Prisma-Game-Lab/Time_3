using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehaviour : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;

	private CharStats charStats;
	private Rigidbody2D rb;

	[SerializeField] private float playerSpeed;

	private Vector2 rawMovementVec;

	public void SetUp()
	{
		playerSpeed = charStats.GetSpeed();
	}

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody2D>();
		charStats = GetComponent<CharStats>();
	}

	public void Start()
	{
		playerSpeed = charStats.GetSpeed();
	}

	private void FixedUpdate()
	{
		MovePlayer();
		TurnPlayer();
	}


	// Metodos relacionados a movimentacao

	public void UpdateMovementVec(Vector2 rawMovementVec)
	{
		this.rawMovementVec = rawMovementVec;
	}

	private void MovePlayer()
	{
		// Limita a magnitude do vetor de movimento a 1, para evitar que movimentos na diagonal sejam mais rapidos
		Vector2 movementVec = Vector2.ClampMagnitude(rawMovementVec, 1);

		// Escala o vetor de acordo com a velocidade do player e o tempo desde o ultimo frame
		movementVec *= playerSpeed * Time.fixedDeltaTime;

		// Aplica a movimentacao
		rb.MovePosition(rb.position + movementVec);
	}


	// Metodos relacionados a girar o jogador

	private void TurnPlayer()
	{
		// TODO: Adicionar compatibilidade com outros controles
		LookAtMouse();
	}

	private void LookAtMouse()
	{
		// Le posicao do mouse na tela
		Vector3 mouse_point = Mouse.current.position.ReadValue();

		// Converte coordenadas pro world space
		mouse_point = Camera.main.ScreenToWorldPoint(mouse_point);

		// Calcula a diferenca entre a posicao atual e a do mouse
		Vector3 look_direction = mouse_point - transform.position;

		// Calcula o angulo em 2D para rotacionar para olhar na direcao certa
		float angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg;

		// Aplica rotacao
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (spriteRenderer != null) {
			if ((angle += 90) < 0) {
				angle += 360;
			}

			if (angle >= 180) {
				spriteRenderer.flipX = false;
			} else {
				spriteRenderer.flipX = true;
			}
		}

	}
}
