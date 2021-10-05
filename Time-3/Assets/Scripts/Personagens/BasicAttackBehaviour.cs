using UnityEngine;

public class BasicAttackBehaviour : MonoBehaviour
{
	private CharStats charStats;

	[SerializeField] private int basicAttackDamage = 1;

	// TODO: se basear nos stats do personagem?
	[SerializeField] private float basicAttackCooldownValue = 1.0f;

	private LayerMask attackLayerMask;
	private float basicAttackCooldown = 0.0f;

	public void SetUp()
	{
		basicAttackDamage = charStats.GetDamage();
	}

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		attackLayerMask = ~(1 << gameObject.layer);
	}

	private void Start()
	{
		SetUp();
	}

	private void Update()
	{
		// Basic Attack cooldown
		// TODO: generalizar cooldown? Corotina?
		basicAttackCooldown -= Time.deltaTime;
		if (basicAttackCooldown < 0)
			basicAttackCooldown = 0;
	}

	public void BasicAttack(bool start)
	{
		if (charStats.GetBasicAttack() == null) return;

		if (start)
			charStats.GetBasicAttack().TriggerSkill();
		else
			charStats.GetBasicAttack().StopSkill();
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

		//Idealmente esse if deve sair com todos os personagens seguindo o mesmo comportamento -Arthur
		// Lista de objetos dentro do range de ataque
		Collider2D[] damageables = Physics2D.OverlapCircleAll(attackLocation, attackSpread, attackLayerMask);

		// Ataca os objetos atacaveis detectados.
		foreach (var entity in damageables) {
			IDamageable<int> damageable = entity.GetComponent<IDamageable<int>>();
			if (damageable != null) {
				damageable.ApplyDamage(basicAttackDamage);
			}
		}

	}
}
