using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour, IDamageable<int>
{
    [SerializeField] private int hp;
    [SerializeField] private float activeTime;

    private void Start() 
    {
        StartCoroutine(Destroy());
    }
	public void Heal()
	{
		return;
	}

	public void ApplyHealing(int healing)
	{
		return;
	}

	public bool ApplyDamage(int damage)
	{
		// TODO: Animacao de dano?

		hp -= damage;
		if (hp <= 0) {
			Die();
			return true;
		}

		return false;
	}

	public void Die()
	{
		// TODO: animacao de morte?
		Destroy(this.gameObject);
	}

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(activeTime);
        Die();
    }
}
