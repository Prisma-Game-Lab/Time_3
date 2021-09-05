using UnityEngine;

public class HostileAI : MonoBehaviour
{
	// TODO: basear em status?
	[SerializeField] private float maxSearchTime = 10.0f;

	private HostileVision vision;
	private HostilePatrol patrolBehaviour;

	private enum State {PATROL, PERSUIT, SEARCH, FIGHT};

	private State currState = State.PATROL;
	private float searchTime;

	private void Awake()
	{
		vision = GetComponent<HostileVision>();
		patrolBehaviour = GetComponent<HostilePatrol>();
		searchTime = maxSearchTime;
	}

	private void Update()
	{
		switch (currState) {
			case State.PATROL:
				if (vision.isPlayerVisible()) {
					currState = State.PERSUIT;
				} else {
					patrolBehaviour.Patrol();
				}
				break;

			case State.PERSUIT:
				if (vision.isPlayerVisible()) {
					// TODO: Persuit movement
					// TODO: if in range, FIGHT
				} else {
					currState = State.SEARCH;
				}
				break;

			case State.SEARCH:
				// TODO: Search movement
				if (vision.isPlayerVisible()) {
					currState = State.PERSUIT;
				} else {
					if (searchTime <= 0) {
						currState = State.PATROL;
						searchTime = maxSearchTime;
					} else {
						searchTime -= Time.deltaTime;
					}
				}
				break;

			case State.FIGHT:
				// TODO: Fight
				// TODO: if player defeated, PATROL
				break;
		}
	}
}
