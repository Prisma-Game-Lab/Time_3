using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]private float moveSpeed = 1.0f;

	private Rigidbody2D rb;
	private PlayerAnimation playerAnimation;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		playerAnimation = FindObjectOfType<PlayerAnimation>();
	}

	private void FixedUpdate()
	{
		float horizontalIn = Input.GetAxis("Horizontal");
		float verticalIn = Input.GetAxis("Vertical");

		Vector2 direction = new Vector2(horizontalIn, verticalIn);
		Vector2 movementVec = Vector2.ClampMagnitude(direction, 1) * moveSpeed;
		Vector2 newPosition = rb.position + movementVec * Time.fixedDeltaTime;

		rb.MovePosition(newPosition);
		playerAnimation.LookDirection(direction);
	}
}
