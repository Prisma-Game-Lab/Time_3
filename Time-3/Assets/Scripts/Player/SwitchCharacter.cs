using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCharacter : MonoBehaviour
{
	[SerializeField] private CharacterBase[] Heroes;
	[SerializeField] private SpriteRenderer spriteRenderer;

	private CharStats charStats;
	private PlayerActions playerinput;
	private HUDManager hudManager;

	private void Awake() {
		playerinput = new PlayerActions();
		hudManager = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDManager>();
	}

	private void Start()
	{
		charStats = GetComponent<CharStats>();
		spriteRenderer.sprite = charStats.GetCharacterBase().sprite;
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
		GetComponent<PlayerController>().UpdateStats();
		if (hudManager != null)
			hudManager.enableCircle(index);
	}
}
