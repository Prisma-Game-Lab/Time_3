using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

	[SerializeField] private Image healthBar;
	[SerializeField] private Image specialBar;
	[SerializeField] private RawImage[] circles;

	private int enabledCircle = 0;

	private void Awake()
	{
		foreach (RawImage circle in circles)
			circle.enabled = false;

		circles[enabledCircle].enabled = true;
	}

	public void setHealthNormalised(float health)
	{
		if (health >= 0.0f && health <= 1.0f)
			healthBar.fillAmount = health;
	}

	public void setHealth(float health, float maxHealth)
	{
		setHealthNormalised(health / maxHealth);
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

	public void enableCircle(int circle)
	{
		if (circle < 0 || circle > circles.Length)
			return;

		circles[enabledCircle].enabled = false;
		enabledCircle = circle;
		circles[enabledCircle].enabled = true;
	}

}

