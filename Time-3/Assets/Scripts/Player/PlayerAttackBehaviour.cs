using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
	private CharStats charStats;

	private LayerMask damageableLayerMask;
	private float basicAttackCooldown = 0.0f;

	[SerializeField] private int basicAttackDamage = 1;

	// TODO: se basear nos stats do personagem?
	[SerializeField] private float basicAttackCooldownValue = 1.0f;

	public void SetUp()
	{
		basicAttackDamage = charStats.getDamage();
	}

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		damageableLayerMask = LayerMask.GetMask("Damageable");
	}

	private void Start()
	{
		SetUp();
	}

	private void Update()
	{
		// Basic Attack cooldown
		// TODO: generalizar cooldown?
		basicAttackCooldown -= Time.deltaTime;
		if (basicAttackCooldown < 0)
			basicAttackCooldown = 0;
	}

	public void BasicAttack()
	{
		// TODO: Animacao de ataque basico

		// TODO: basear em stats dos personagens?
		const float attackSpread = 0.5f;
		const float attackRange = 0.5f;

		if (basicAttackCooldown > 0) return;
		basicAttackCooldown = basicAttackCooldownValue;

		// Calcula o ponto de ataque, em frente do personagem
		Vector3 attackLocation = transform.position;
		attackLocation += transform.right * attackRange; // Em 2D, no eixo usado, "frete" eh transform.right

		// Lista de objetos dentro do range de ataque
		Collider2D[] damageables = Physics2D.OverlapCircleAll(attackLocation, attackSpread, damageableLayerMask);

		// Ataca os objetos atacaveis detectados.
		foreach (var entity in damageables) {
			IDamageable<int> damageable = entity.GetComponent<IDamageable<int>>();
			if (damageable != null) {
				damageable.ApplyDamage(basicAttackDamage);
			}
		}

	}
}
