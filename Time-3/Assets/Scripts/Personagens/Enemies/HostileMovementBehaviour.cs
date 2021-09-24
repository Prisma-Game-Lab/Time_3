using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HostileMovementBehaviour : MonoBehaviour
{
	[SerializeField] private float rotationSpeed = 5.0f;

	private CharStats charStats;
	private Rigidbody2D rb;

	private float speed;
	private Quaternion targetDir;
	private Vector3 targetPos;
	private Vector3 endTargetPos;

	private Stack<Vector3> movementStack;
	private Pathfinding pathfinding;

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		rb = GetComponent<Rigidbody2D>();
		movementStack = new Stack<Vector3>();
		endTargetPos = transform.position;
		targetPos = transform.position;
	}

	private void Start()
	{
		pathfinding = Pathfinding.Instance;
		speed = charStats.GetSpeed();
		targetPos = transform.position;
		targetDir = transform.rotation;
	}

	public void setRotSpeed(float rotationSpeed)
	{
		if (speed >= 0) {
			this.rotationSpeed = rotationSpeed;
		}
	}

	public float getRotSpeed()
	{
		return rotationSpeed;
	}

	public void UpdateMovement()
	{
		speed = charStats.GetSpeed();
		rb.MovePosition(Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime));
		transform.rotation = Quaternion.Lerp(transform.rotation, targetDir, rotationSpeed * Time.fixedDeltaTime);

		if (Mathf.Abs(Vector3.Distance(transform.position, targetPos)) < 0.1 && movementStack.Count > 0) {
			targetPos = movementStack.Pop();
		}
	}

	public void MoveTo(Vector3 dest)
	{
		if (Vector3.Distance(dest, endTargetPos) > 0.01) {
			endTargetPos = dest;

			movementStack = pathfinding.MakePath(transform.position, endTargetPos);
			if (movementStack == null) {
				movementStack = new Stack<Vector3>();
				targetPos = transform.position;
			} else {
				targetPos = movementStack.Pop();
			}
		}
	}

	public void Face(float angle) => targetDir = Quaternion.AngleAxis(angle, Vector3.forward);

	public void Face(Vector3 target)
	{
		Vector2 lookDirection = target - transform.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		Face(angle);
	}

	public void FaceRandom()
	{
		float randomAngle = Random.Range(0.0f, 360.0f);
		Face(randomAngle);
	}

}
