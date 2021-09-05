using UnityEngine;

public class HostileMovementBehaviour : MonoBehaviour
{
	[SerializeField] private float rotSmooth = 5.0f;

	private CharStats charStats;

	private float speed;
	private Quaternion targetDir;
	private Vector3 targetPos;

	private void Awake() => charStats = GetComponent<CharStats>();

	private void Start()
	{
		speed = charStats.getSpeed();
		targetPos = transform.position;
		targetDir = transform.rotation;
	}

	public void UpdateMovement()
	{
		speed = charStats.getSpeed();
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetDir, rotSmooth * Time.deltaTime);
	}

	public void MoveTo(Vector3 dest) => targetPos = dest;

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
