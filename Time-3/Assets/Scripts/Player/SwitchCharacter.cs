using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCharacter : MonoBehaviour
{
	[SerializeField] private CharacterBase[] Heroes;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private SpriteRenderer Head;
	[SerializeField] private HeadOffset headOffset;
	private CharStats charStats;
	private PlayerActions playerinput;
	[SerializeField] private Animator animator;

	private void Awake() {
		playerinput = new PlayerActions();
	}

	void Start()
	{
		charStats = GetComponent<CharStats>();
		spriteRenderer.sprite = charStats.GetCharacterBase().sprite;
		Head.sprite= charStats.GetCharacterBase().head;
		//Pode ser uma variável global para um personagem default/favorito
		SwitchHero(0);
	}

	// Update is called once per frame

	public void hero1(InputAction.CallbackContext context){
		if (!context.ReadValueAsButton() || context.performed) return;
		SwitchHero(0);
	}

	public void hero2(InputAction.CallbackContext context){
		if (!context.ReadValueAsButton() || context.performed) return;
		SwitchHero(1);
	}

	public void hero3(InputAction.CallbackContext context){
		if (!context.ReadValueAsButton() || context.performed) return;
		SwitchHero(2);
	}

	private void SwitchHero(int index)
	{
		charStats.SetCharbase(Heroes[index]);
		spriteRenderer.sprite = charStats.GetCharacterBase().sprite;
		Head.sprite =charStats.GetCharacterBase().head;
		GetComponent<PlayerController>().UpdateStats();
		headOffset.offsetUpdate(charStats.GetHeadOffset());
		animator.runtimeAnimatorController = charStats.GetRuntimeAnimatorController();
	}
}
