using UnityEngine;

[RequireComponent(typeof(HostileStats))]
public class HostileController : MonoBehaviour, IDamageable<int>
{
	private HostileStats hostileStats;
	private GameObject player;

	private void Awake()
	{
		hostileStats = GetComponent<HostileStats>();
		player = GameObject.FindWithTag("Player");
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

		player.GetComponent<PlayerInventoryBehaviour>().IncCredits(hostileStats.GetDropValue());

		Destroy(this.gameObject);
	}
}
