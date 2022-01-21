using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PirateMineBehaviour : MonoBehaviour
{
	[SerializeField] private float detect_radius;
	[SerializeField] private float blast_radius;
	[SerializeField] private int blast_damage;
	[SerializeField] private int blast_time;

	private void Awake() 
	{
		StartCoroutine(StartBlast());
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		Collider2D[] damageables = Physics2D.OverlapCircleAll(transform.position, blast_radius);

		if (other.tag == "Player" || other.tag == "Ignore")
			return;

		FindObjectOfType<AudioManager>().Play("pirata ovo explode");
		
		foreach (var entity in damageables) {
			if (entity.tag == "Player" || entity.tag == "Ignore") continue;
			IDamageable<int> damageable = entity.GetComponent<IDamageable<int>>();
			if (damageable != null) {
				damageable.ApplyDamage(blast_damage);
			}
		}

		Destroy(gameObject);
	}


	private IEnumerator StartBlast()
	{
		yield return new WaitForSeconds(blast_time);

		Collider2D[] damageables = Physics2D.OverlapCircleAll(transform.position, blast_radius);

		FindObjectOfType<AudioManager>().Play("pirata ovo explode");
		
		foreach (var entity in damageables) {
			if (entity.tag == "Player" || entity.tag == "Ignore") continue;
			IDamageable<int> damageable = entity.GetComponent<IDamageable<int>>();
			if (damageable != null) {
				damageable.ApplyDamage(blast_damage);
			}
		}

		Destroy(gameObject);
	}
}

