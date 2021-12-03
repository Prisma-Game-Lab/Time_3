using UnityEngine;

public class HostileAI : MonoBehaviour
{
	// TODO: basear em status?
	[SerializeField] private float maxSearchTime = 10.0f;

	private IHostileDetection detectionBehaviour;
	private IHostilePatrol patrolBehaviour;
	private IHostilePersuit persuitBehaviour;
	private IHostileSearch searchBehaviour;

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

	public void Aggro()
	{
		CurrState = State.PERSUIT;
	}

	private void Awake()
	{
		detectionBehaviour = GetComponent<IHostileDetection>();
		patrolBehaviour = GetComponent<IHostilePatrol>();
		persuitBehaviour = GetComponent<IHostilePersuit>();
		searchBehaviour = GetComponent<IHostileSearch>();
		searchTime = maxSearchTime;
	}

	private void Update()
	{
		switch (CurrState) {
			case State.PATROL:
				if (detectionBehaviour.isPlayerDetectable()) {
					CurrState = State.PERSUIT;
				} else {
					patrolBehaviour.Patrol();
				}
				break;

			case State.PERSUIT:
				if (detectionBehaviour.isPlayerDetectable()) {
					persuitBehaviour.Persuit();
					// TODO: if player defeated, PATROL
				} else {
					CurrState = State.SEARCH;
				}
				break;

			case State.SEARCH:
				if (detectionBehaviour.isPlayerDetectable()) {
					CurrState = State.PERSUIT;
				} else {
					searchBehaviour.Search();
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

