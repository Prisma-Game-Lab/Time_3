using UnityEngine;

public class HostileDetection : MonoBehaviour
{
	private CharStats charStats;
	[SerializeField] private GameObject player;

	// TODO: base on stats
	[SerializeField] private float fov = 120.0f;
	[SerializeField] private float viewDistance = 4.0f;
	[SerializeField] private float hearingDistance = 2.0f;
	[SerializeField] private LayerMask ignoreMask;

	private LayerMask raycastLayers;

	void Awake()
	{
		charStats = GetComponent<CharStats>();
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}

		// Ignore own mask
		raycastLayers = ~(ignoreMask | (1 << gameObject.layer));

	}

	public bool isPlayerDetectable()
	{
		Vector3 pPosition = player.GetComponentInParent<Transform>().position;

		// Player within distance?
		float distance = Vector2.Distance(pPosition, transform.position);

		if (distance <= hearingDistance) {
			return true;
		}

		if (distance <= viewDistance) {

			// Player within fov?
			float angle = Vector2.Angle(pPosition - transform.position, transform.right);
			if (angle < fov/2) {

				// Player visible?
				RaycastHit2D hit = Physics2D.Raycast(
						transform.position,
						(pPosition - transform.position).normalized,
						distance, raycastLayers);
				Debug.DrawRay(transform.position, (pPosition - transform.position).normalized * distance, Color.red, 1);

				if (hit.collider.tag == "Player") {
					return true;
				}
			}
		}

		return false;
	}
}
