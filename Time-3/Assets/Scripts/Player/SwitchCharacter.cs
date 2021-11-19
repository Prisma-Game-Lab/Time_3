using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class SwitchCharacter : MonoBehaviour, IObservable<int>
{
	[SerializeField] private CharacterBase[] Heroes;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private SpriteRenderer Head;
	[SerializeField] private HeadOffset headOffset;
	private CharStats charStats;
	private PlayerActions playerinput;
	[SerializeField] private Animator animator;

	private List<IObserver<int>> observers;

	private void Awake() {
		playerinput = new PlayerActions();
		observers = new List<IObserver<int>>();
	}

	private void Start()
	{
		charStats = GetComponent<CharStats>();
		spriteRenderer.sprite = charStats.GetCharacterBase().sprite;
		Head.sprite= charStats.GetCharacterBase().head;
		//Pode ser uma variável global para um personagem default/favorito
		SwitchHero(0);
	}

	// Observable
	public virtual void subscribe(IObserver<int> observer) => observers.Add(observer);
	public virtual void unsubscribe(IObserver<int> observer) => observers.Remove(observer);

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
		charStats.ChangeCharbase(Heroes[index]);
		spriteRenderer.sprite = charStats.GetCharacterBase().sprite;
		Head.sprite =charStats.GetCharacterBase().head;
		GetComponent<PlayerController>().UpdateStats();
		headOffset.offsetUpdate(charStats.GetHeadOffset());
		animator.runtimeAnimatorController = charStats.GetRuntimeAnimatorController();

		observers.ForEach(o => o.update(index));
	}
}
