using UnityEngine;

public class HostilePatrol : MonoBehaviour
{

	[SerializeField] private float speed = 5.0f;
	[SerializeField] private float watchTime = 5.0f;
	[SerializeField] private Transform[] waypoints;

	private int targetWayPoint = 0;
	private Vector3 targetPos;
	private float remainWatchTime;
	private float lookTime;

	private void Start()
	{
		SetUpPatrol();
	}

	public void SetUpPatrol()
	{
		targetPos = waypoints[targetWayPoint].position;
		remainWatchTime = watchTime;
		lookTime = -1;
	}

	// TODO: Separar em funcoes
	// TODO: Modularizar sistema de movimentacao
	public void Patrol()
	{
		// TODO: simplificar com corrotinas?
		// TODO: Deixar rotacoes mais suaves
		if (Vector2.Distance(transform.position, targetPos) < 0.05f) {
			if (remainWatchTime <= 0) {
				lookTime = -1;
				if (++targetWayPoint >= waypoints.Length) {
					targetWayPoint = 0;
				}
				targetPos = waypoints[targetWayPoint].position;
				remainWatchTime = watchTime;
			} else {
				if (lookTime <= 0) {
					lookTime = Random.Range(0, watchTime);
					float randomAngle = Random.Range(0.0f, 360.0f);
					transform.rotation = Quaternion.AngleAxis(randomAngle, Vector3.forward);
				} else {
					lookTime -= Time.deltaTime;
				}
				remainWatchTime -= Time.deltaTime;
			}
		} else {

			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

			Vector2 look_direction = targetPos - transform.position;
			float angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

}
