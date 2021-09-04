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
		charStats.setCurHp(charStats.getMaxHp() - charStats.getMaxHp());
	}

	public void ApplyHealing(int healing)
	{
		charStats.setCurHp(healing);
	}

	public bool ApplyDamage(int damage)
	{
		// TODO: Animacao de dano?

		charStats.setCurHp(-damage);
		if (charStats.getCurHp() < 1) {
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
