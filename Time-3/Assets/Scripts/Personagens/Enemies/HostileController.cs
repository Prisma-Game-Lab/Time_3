using UnityEngine;

[RequireComponent(typeof(CharStats))]
public class HostileController : MonoBehaviour, IDamageable<int>
{
	private CharStats charStats;

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
	}

	public void Heal()
	{
		charStats.SetCurrHp(charStats.GetMaxHp());
	}

	public void ApplyHealing(int healing)
	{
		charStats.IncCurrHp(healing);
	}

	public bool ApplyDamage(int damage)
	{
		// TODO: Animacao de dano?

		charStats.IncCurrHp(-damage);
		if (charStats.GetCurrHp() <= 0) {
			Die();
			return true;
		}

		return false;
	}

	public void Die()
	{
		// TODO: Drop drops (balas)
		// TODO: animacao de morte?

		Destroy(this.gameObject);
	}
}
