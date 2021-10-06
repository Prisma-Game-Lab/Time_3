using UnityEngine;

public class PirateMineBehaviour : MonoBehaviour
{
	[SerializeField] private float detect_radius;
	[SerializeField] private float blast_radius;
	[SerializeField] private int blast_damage;

	private void OnTriggerEnter2D(Collider2D other)
	{
		bool detonated = false;
		Collider2D[] damageables = Physics2D.OverlapCircleAll(transform.position, blast_radius);

		foreach (var entity in damageables) {
			if (entity.tag == "Player" || entity.tag == "Ignore") continue;
			IDamageable<int> damageable = entity.GetComponent<IDamageable<int>>();
			if (damageable != null) {
				detonated = true;
				damageable.ApplyDamage(blast_damage);
			}
		}

		if (detonated)
			Destroy(gameObject);
	}

}

