using UnityEngine;
using UnityEngine.InputSystem;

//Usar RequireComponent para adicionar componentes automaticamente ao jogador -Arthur
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharStats))]
[RequireComponent(typeof(PlayerAttackBehaviour))]
[RequireComponent(typeof(PlayerMovementBehaviour))]
public class PlayerController : MonoBehaviour
{
	private CharStats charStats;

	private PlayerMovementBehaviour pMovementBehaviour;
	private PlayerAttackBehaviour pAttackBehaviour;

	private PlayerSkillBehaviour pSkillBehaviour;

	private void Awake()
	{
		charStats = GetComponent<CharStats>();
		pAttackBehaviour = GetComponent<PlayerAttackBehaviour>();
		pMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
		pSkillBehaviour = GetComponent<PlayerSkillBehaviour>();
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
		// Peculiaridades do InputSystem :)
		if (!context.ReadValueAsButton() || context.performed) return;

		pAttackBehaviour.BasicAttack();
	}

	public void UpdateStats()
	{
		pMovementBehaviour.SetUp();
		pAttackBehaviour.SetUp();
		pSkillBehaviour.SetUp();
	}
}
