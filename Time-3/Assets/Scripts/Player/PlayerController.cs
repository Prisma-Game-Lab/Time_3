using UnityEngine;
using UnityEngine.InputSystem;

//Usar RequireComponent para adicionar componentes automaticamente ao jogador -Arthur
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharStats))]
[RequireComponent(typeof(PlayerMovementBehaviour))]
[RequireComponent(typeof(BasicAttackBehaviour))]
public class PlayerController : MonoBehaviour, IDamageable<int>
{
	private CharStats charStats;
	private PlayerMovementBehaviour pMovementBehaviour;
	private BasicAttackBehaviour pAttackBehaviour;
	private PlayerSkillBehaviour pSkillBehaviour;

	private bool movement_lock = false;

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		pAttackBehaviour = GetComponent<BasicAttackBehaviour>();
		pMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
		pSkillBehaviour = GetComponent<PlayerSkillBehaviour>();
	}

	public void Die()
	{
		// TODO: Animacao de morte
		// TODO: Respawn/Restart
		Debug.Log("Player morreu!");
		Heal();
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
		charStats.IncCurrHp(-damage);
		if (charStats.GetCurrHp() <= 0) {
			Die();
			return true;
		}

		return false;
	}

	/// Evento ativado pelo InputSystem para movimentacao
	public void onMovement(InputAction.CallbackContext context)
	{
		if (movement_lock) return;
		// Le o vetor de movimento bruto passado pelo InputSystem
		Vector2 rawMovementVector = context.ReadValue<Vector2>();
		pMovementBehaviour.UpdateMovementVec(rawMovementVector);
	}

	/// Evento ativado pelo InputSystem para ataques basicos
	public void onAttack(InputAction.CallbackContext context)
	{
		if (context.started) { // Press
			movement_lock = true;
			pAttackBehaviour.BasicAttack(true);
		} else if (context.canceled) { // Release
			pAttackBehaviour.BasicAttack(false);
			movement_lock = false;
		}
	}

	public void onCombatSkillActivation(InputAction.CallbackContext context)
	{
		pSkillBehaviour.ActivateSkill(charStats.GetCombatSkill());
	}

	public void onExplorationSkillActivation(InputAction.CallbackContext context)
	{
		pSkillBehaviour.ActivateSkill(charStats.GetExplorationSkill());
	}

	public void UpdateStats()
	{
		pMovementBehaviour.SetUp();
		pAttackBehaviour.SetUp();
		pSkillBehaviour.SetUp();
	}
}
