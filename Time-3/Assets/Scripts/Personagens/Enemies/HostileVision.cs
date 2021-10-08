using UnityEngine;

public class HostileVision : MonoBehaviour
{
	private CharStats charStats;
	[SerializeField] private GameObject player;

	// TODO: base on stats
	[SerializeField] private float fov = 90.0f;
	[SerializeField] private float viewDistance = 3.0f;
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

	public bool isPlayerVisible()
	{
		Vector3 pPosition = player.GetComponentInParent<Transform>().position;

		// Player within distance?
		float distance = Vector2.Distance(pPosition, transform.position);
		if (distance < viewDistance) {

			// Player within fov?
			float angle = Vector2.Angle(pPosition - transform.position, transform.right);
			if (angle < fov/2) {
				Debug.Log("fov");

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
