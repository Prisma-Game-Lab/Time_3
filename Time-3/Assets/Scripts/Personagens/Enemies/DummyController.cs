using UnityEngine;

[RequireComponent(typeof(CharStats))]
public class DummyController : MonoBehaviour
{
	CharStats chartStats;

	private void Awake()
	{
		chartStats = GetComponent<CharStats>();
	}

	public void ApplyDamage(int damage)
	{
		// TODO: Animacao de dano?

		chartStats.setCurHp(-damage);
		if (chartStats.getCurHp() < 1) {
			Destroy(this.gameObject);
		}
	}
}
