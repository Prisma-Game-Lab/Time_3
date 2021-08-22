using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private static readonly string[] directions = {"StaticN", "StaticNW",
		"StaticW", "StaticSW", "StaticS", "StaticSE", "StaticE", "StaticNE"};

	private Animator animator;
	private int lastDirection; /* Keep looking to the same direction after moving */

	private void Awake()
	{
		animator = GetComponent<Animator>();
		lastDirection = 4; /* StaticS */
	}

	public void LookDirection(Vector2 direction)
	{
		if (direction.magnitude >= 0.01)
			lastDirection = DirectionToIndex(direction);
		animator.Play(directions[lastDirection]);
	}

	private int DirectionToIndex(Vector2 direction)
	{
		const float step = 360 / 8; /* 8 possible positions and animations */

		float angle = Vector2.SignedAngle(Vector2.up, direction.normalized); /* Vector2.up == bottom to up */
		if (angle < 0) /* Keep angles positive */
			angle += 360;

		return Mathf.FloorToInt(angle / step);
	}
}
