using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehaviour : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject head;
	[SerializeField] private float MaxplayerSpeed;
	[SerializeField] private float playerSpeed;

	public Animator animator;

	private CharStats charStats;
	private Rigidbody2D rb;
	private SpriteRenderer headSprite;
	private Vector2 rawMovementVec;
	private Vector2 movementVec;

	public void SetUp()
	{
		MaxplayerSpeed = charStats.GetSpeed();
		headSprite = head.GetComponent<SpriteRenderer>();
	}

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody2D>();
		charStats = GetComponent<CharStats>();
	}

	public void Start()
	{
		MaxplayerSpeed = charStats.GetSpeed();
	}
	//para retornar ao valor do charBase depois do ataque
	public void ResetSpeed(){
		MaxplayerSpeed = charStats.GetSpeed();
	}

	private void FixedUpdate()
	{
		MovePlayer();
		if(playerSpeed<0.01){
			TurnPlayer();
		}
	}
	private void Update() {
		playerSpeed = movementVec.magnitude;
		animator.SetFloat("Horizontal", movementVec.x);
		Debug.Log(movementVec.x);
		animator.SetFloat("Speed",playerSpeed);
	}

	// Metodos relacionados a movimentacao

	public void UpdateMovementVec(Vector2 rawMovementVec)
	{
		this.rawMovementVec = rawMovementVec;
	}

	private void MovePlayer()
	{
		// Limita a magnitude do vetor de movimento a 1, para evitar que movimentos na diagonal sejam mais rapidos
		movementVec = Vector2.ClampMagnitude(rawMovementVec, 1);

		// Escala o vetor de acordo com a velocidade do player e o tempo desde o ultimo frame
		movementVec *= MaxplayerSpeed * Time.fixedDeltaTime;

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
				spriteRenderer.flipX = true;
				headSprite.flipX = true;
			} else {
				spriteRenderer.flipX = false;
				headSprite.flipX = false;
			}

			if (head != null) {
				Vector3 axis;
				float rotAngle;

				if (angle >= 180) {
					axis = Vector3.forward;
					rotAngle = angle + 90.0f;

					if (rotAngle < 330.0f)
						rotAngle = 330.0f;
					else if (rotAngle > 390.0f)
						rotAngle = 390.0f;
				} else {
					axis = Vector3.forward;
					rotAngle = angle - 90.0f;
					if (rotAngle < -30.0f)
						rotAngle = -30.0f;
					else if (rotAngle > 30.0f)
						rotAngle = 30.0f;
				}

				head.GetComponent<Transform>().rotation = Quaternion.AngleAxis(rotAngle, axis);
			}
		}

	}
	public float GetSpeed(){
		return MaxplayerSpeed;
	}
	public void SetSpeed(float n){
		MaxplayerSpeed = n;
	}
}
