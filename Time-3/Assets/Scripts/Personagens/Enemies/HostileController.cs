using UnityEngine;

[RequireComponent(typeof(HostileStats))]
[RequireComponent(typeof(HostileMovementBehaviour))]
public class HostileController : MonoBehaviour, IDamageable<int>
{
	private HostileStats hostileStats;
	private GameObject player;
	private HostileMovementBehaviour movementBehaviour;

	private void Awake()
	{
		hostileStats = GetComponent<HostileStats>();
		player = GameObject.FindWithTag("Player");
		movementBehaviour = GetComponent<HostileMovementBehaviour>();
	}

	private void FixedUpdate()
	{
		movementBehaviour.UpdateMovement();
	}

	public void Heal()
	{
		hostileStats.SetCurrHp(hostileStats.GetMaxHp());
	}

	public void ApplyHealing(int healing)
	{
		hostileStats.IncCurrHp(healing);
	}

	public bool ApplyDamage(int damage)
	{
		// TODO: Animacao de dano?

		hostileStats.IncCurrHp(-damage);
		if (hostileStats.GetCurrHp() <= 0) {
			Die();
			return true;
		}

		return false;
	}

	public void Die()
	{
		// TODO: animacao de morte?

		player.GetComponentInChildren<PlayerInventoryBehaviour>().IncCredits(hostileStats.GetDropValue());

		Destroy(this.gameObject);
	}
}
