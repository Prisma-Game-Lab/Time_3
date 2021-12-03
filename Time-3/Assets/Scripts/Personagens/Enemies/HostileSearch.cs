using UnityEngine;

public class HostileSearch : MonoBehaviour, IHostileSearch
{
	private HostileMovementBehaviour movBehaviour;

	// TODO: Passar alvo de forma menos fixa
	[SerializeField] private Transform target;

	private void Awake()
	{
		movBehaviour = GetComponent<HostileMovementBehaviour>();
	}

	private void Start() => target = GameObject.FindWithTag("Player").transform;

	public void StartSearch()
	{
		movBehaviour.setRotSpeed(100.0f);
	}

	public void Search()
	{
		movBehaviour.MoveTo(target.position);
		movBehaviour.Face(target.position);
	}

}
