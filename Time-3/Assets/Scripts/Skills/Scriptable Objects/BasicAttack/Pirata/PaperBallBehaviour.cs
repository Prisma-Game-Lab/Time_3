using System.Collections;
using UnityEngine;

public class PaperBallBehaviour : MonoBehaviour
{
	[SerializeField] private CharacterBase character;
	[SerializeField] private float despawn_time;

	private float speed = -1;

	private void Init(float speed) {
		this.speed = speed;
		GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
		StartCoroutine(Despawn());
	}

	private IEnumerator Despawn()
	{
		while (speed < 0);
		yield return new WaitForSeconds(despawn_time);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		IDamageable<int> damageable = other.gameObject.GetComponent<IDamageable<int>>();
		if (damageable != null && other.tag == "Enemy") {
			damageable.ApplyDamage(character.baseDamage);
			Destroy(gameObject);
		}

		if (other.tag != "Ignore" && other.tag != "Player")
			Destroy(gameObject);
	}

}
