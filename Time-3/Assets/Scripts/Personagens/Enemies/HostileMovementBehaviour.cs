using UnityEngine;

public class HostileMovementBehaviour : MonoBehaviour
{
	[SerializeField] private float speed;

	private CharStats charStats;

	private void Awake() => charStats = GetComponent<CharStats>();
	private void Start() => speed = charStats.getSpeed();

	public void MoveTo(Vector3 dest)
	{
		transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
	}

	// TODO: Deixar rotacoes mais suaves
	public void Face(Vector3 target)
	{
		Vector2 lookDirection = target - transform.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		Face(angle);
	}

	public void Face(float angle)
	{
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void FaceRandom()
	{
		float randomAngle = Random.Range(0.0f, 360.0f);
		Face(randomAngle);
	}

}
