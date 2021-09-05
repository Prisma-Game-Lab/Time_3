using UnityEngine;

public class HostilePersuit : MonoBehaviour
{
	private HostileMovementBehaviour movBehaviour;

	// TODO: Basear em stats de ataque/personagem
	[SerializeField] private float attackRange = 1.5f;

	// TODO: Passar alvo de forma menos fixa
	[SerializeField] private Transform target;

	private void Awake() => movBehaviour = GetComponent<HostileMovementBehaviour>();
	private void Start() => target = GameObject.FindWithTag("Player").transform;

	public void StartPersuit()
	{
		movBehaviour.setRotSpeed(100.0f);
	}

	public void Persuit()
	{
		if (targetInRange()) {
			// TODO: if in range, FIGHT
			movBehaviour.MoveTo(transform.position);
		} else {
			movBehaviour.MoveTo(target.position);
		}
		movBehaviour.Face(target.position);
		movBehaviour.UpdateMovement();
	}

	private bool targetInRange()
	{
		return Vector3.Distance(transform.position, target.position) < attackRange;
	}
}
