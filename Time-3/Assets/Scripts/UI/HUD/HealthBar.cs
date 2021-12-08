using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IObserver<float>
{
	[SerializeField] private Image healthBar;

	public void update(float health)
	{
		if (health >= 0.0f && health <= 1.0f)
			healthBar.fillAmount = health;
	}

}
