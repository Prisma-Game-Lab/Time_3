using UnityEngine;

public class HostilePatrol : MonoBehaviour, IHostilePatrol
{
	private HostileMovementBehaviour movBehaviour;

	[SerializeField] private float watchTime = 5.0f;
	[SerializeField] private Transform[] waypoints;

	private int targetWayPoint = 0;
	private Vector3 targetPos;
	private float remainWatchTime;
	private float lookTime;

	private void Awake()
	{
		movBehaviour = GetComponent<HostileMovementBehaviour>();
	}

	private void Start()
	{
		StartPatrol();
	}

	public void StartPatrol()
	{
		movBehaviour.setRotSpeed(5.0f);
		targetPos = waypoints[targetWayPoint].position;
		remainWatchTime = watchTime;
		lookTime = -1;
	}

	// TODO: Separar em funcoes
	public void Patrol()
	{
		// TODO: simplificar com corrotinas?
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
					movBehaviour.FaceRandom();
				} else {
					lookTime -= Time.deltaTime;
				}
				remainWatchTime -= Time.deltaTime;
			}
		} else {
			movBehaviour.MoveTo(targetPos);
			movBehaviour.Face(targetPos);
		}

	}

}
