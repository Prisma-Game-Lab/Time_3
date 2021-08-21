using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]private float moveSpeed = 1.0f;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		float horizontalIn = Input.GetAxis("Horizontal");
		float verticalIn = Input.GetAxis("Vertical");
		Vector2 position = rb.position;
		Vector2 movementVec = new Vector2(horizontalIn, verticalIn);
		movementVec = Vector2.ClampMagnitude(movementVec, 1);
		movementVec = movementVec * moveSpeed;
		position += movementVec * Time.fixedDeltaTime;
		rb.MovePosition(position);

		FindObjectOfType<PlayerAnimation>().LookDirection(new Vector2(horizontalIn, verticalIn));
	}
}
