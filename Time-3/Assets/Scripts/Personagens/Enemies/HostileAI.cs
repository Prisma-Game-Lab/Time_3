using UnityEngine;

public class HostileAI : MonoBehaviour
{
	// TODO: basear em status?
	[SerializeField] private float maxSearchTime = 10.0f;

	private HostileVision vision;
	private HostilePatrol patrolBehaviour;
	private HostilePersuit persuitBehaviour;

	private enum State {PATROL, PERSUIT, SEARCH};

	private State currState = State.PATROL;

	private State CurrState
	{
		get {return currState; }
		set {
			switch (value) {
				case State.PATROL:
					patrolBehaviour.StartPatrol();
					break;
				case State.PERSUIT:
					persuitBehaviour.StartPersuit();
					break;
				case State.SEARCH:
					break;
			}

			currState = value;
		}
	}

	private float searchTime;

	private void Awake()
	{
		vision = GetComponent<HostileVision>();
		patrolBehaviour = GetComponent<HostilePatrol>();
		persuitBehaviour = GetComponent<HostilePersuit>();
		searchTime = maxSearchTime;
	}

	private void Update()
	{
		switch (CurrState) {
			case State.PATROL:
				if (vision.isPlayerVisible()) {
					CurrState = State.PERSUIT;
				} else {
					patrolBehaviour.Patrol();
				}
				break;

			case State.PERSUIT:
				if (vision.isPlayerVisible()) {
					persuitBehaviour.Persuit();
					// TODO: if player defeated, PATROL
				} else {
					CurrState = State.SEARCH;
				}
				break;

			case State.SEARCH:
				// TODO: Search movement
				if (vision.isPlayerVisible()) {
					CurrState = State.PERSUIT;
				} else {
					if (searchTime <= 0) {
						CurrState = State.PATROL;
						searchTime = maxSearchTime;
					} else {
						searchTime -= Time.deltaTime;
					}
				}
				break;
		}
	}
}
