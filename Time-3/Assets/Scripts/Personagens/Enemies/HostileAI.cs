using UnityEngine;

public class HostileAI : MonoBehaviour
{
	private enum State {PATROL, PERSUIT, SEARCH, FIGHT};

	private State currState = State.PATROL;

	private HostileVision vision;

	private void Awake()
	{
		vision = GetComponent<HostileVision>();
	}

	private void Update()
	{
		switch (currState) {
			case State.PATROL:
				// TODO: Patrol movement
				if (vision.isPlayerVisible()) {
					currState = State.PERSUIT;
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
					// TODO: if time ellapsed, PATROL
				}
				break;

			case State.FIGHT:
				// TODO: Fight
				// TODO: if player defeated, PATROL
				break;
		}
	}
}
