using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

	[SerializeField] private Image specialBar;
	[SerializeField] private HealthBar healthBar;
	[SerializeField] private CharacterSelection charSelection;

	private void Start()
	{
		GameObject.FindGameObjectWithTag("Player")
			.GetComponent<SwitchCharacter>()
			.subscribe((IObserver<int>)charSelection);

		GameObject.FindGameObjectWithTag("Player")
			.GetComponent<PlayerController>()
			.subscribe((IObserver<float>)healthBar);
	}

	public void setSpecialNormalised(float special)
	{
		if (special >= 0.0f && special <= 1.0f)
			specialBar.fillAmount = special;
	}

	public void setSpecial(float special)
	{
		setSpecialNormalised(special / 100.0f);
	}

}

