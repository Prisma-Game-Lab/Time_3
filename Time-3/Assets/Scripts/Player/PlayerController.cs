using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//Usar RequireComponent para adicionar componentes automaticamente ao jogador -Arthur
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharStats))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerMovementBehaviour))]
[RequireComponent(typeof(SwitchCharacter))]
[RequireComponent(typeof(PlayerSkillBehaviour))]
[RequireComponent(typeof(BasicAttackBehaviour))]
[RequireComponent(typeof(PlayerInventoryBehaviour))]
[RequireComponent(typeof(PlayerInteraction))]
public class PlayerController : MonoBehaviour, IDamageable<int>, IObservable<float>
{
	[SerializeField] private HUDManager hudManager;
	private CharStats charStats;
	private PlayerMovementBehaviour pMovementBehaviour;
	private BasicAttackBehaviour pAttackBehaviour;
	private PlayerSkillBehaviour pSkillBehaviour;
	[SerializeField] private GameObject head;

	private List<IObserver<float>> observers;

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		pAttackBehaviour = GetComponent<BasicAttackBehaviour>();
		pMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
		pSkillBehaviour = GetComponent<PlayerSkillBehaviour>();
		observers = new List<IObserver<float>>();
		hudManager = FindObjectOfType<HUDManager>();
	}

	public void subscribe(IObserver<float> observer) => observers.Add(observer);
	public void unsubscribe(IObserver<float> observer) => observers.Remove(observer);

	public void Die()
	{
		// TODO: Animacao de morte
		// TODO: Respawn/Restart
		Debug.Log("Player morreu!");
		SceneManager.LoadScene("GameOver");
	}

	public void Heal()
	{
		charStats.SetCurrHp(charStats.GetMaxHp());
		observers.ForEach(o => o.update(1.0f));
	}

	public void ApplyHealing(int healing)
	{
		charStats.IncCurrHp(healing);
		float normalisedHealth = (float)charStats.GetCurrHp() / charStats.GetMaxHp();
		observers.ForEach(o => o.update( normalisedHealth ));
	}

	public bool ApplyDamage(int damage)
	{
		damage = (int)(damage * (1.0f - charStats.GetDefense()));
		charStats.IncCurrHp(-damage);
		if (charStats.GetCurrHp() <= 0) {
			Die();
			return true;
		}

		float normalisedHealth = (float)charStats.GetCurrHp() / charStats.GetMaxHp();
		observers.ForEach(o => o.update( normalisedHealth ));

		return false;
	}

	/// Evento ativado pelo InputSystem para movimentacao
	public void onMovement(InputAction.CallbackContext context)
	{
		// Le o vetor de movimento bruto passado pelo InputSystem
		Vector2 rawMovementVector = context.ReadValue<Vector2>();
		pMovementBehaviour.UpdateMovementVec(rawMovementVector);
	}

	/// Evento ativado pelo InputSystem para ataques basicos
	public void onAttack(InputAction.CallbackContext context)
	{
		if (context.started) { // Press
			pSkillBehaviour.ActivateSkill(charStats.GetBasicAttack());

		} else if (context.canceled && charStats.GetBasicAttack().state=="active") { // Release
			pAttackBehaviour.BasicAttack(false);
			pMovementBehaviour.ResetSpeed();
		}
	}
	public void onCombatSkillActivation(InputAction.CallbackContext context)
	{
		if (context.started){
			pSkillBehaviour.ActivateSkill(charStats.GetCombatSkill());
		}
	}

	public void onExplorationSkillActivation(InputAction.CallbackContext context)
	{
		if (context.started)
			pSkillBehaviour.ActivateSkill(charStats.GetExplorationSkill());
	}

	public void UpdateStats()
	{
		pMovementBehaviour.SetUp();
		pAttackBehaviour.SetUp();
		pSkillBehaviour.SetUp();
	}
}
