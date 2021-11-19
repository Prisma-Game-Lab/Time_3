using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour, IObserver<int>
{
	[SerializeField] private RawImage[] circles;

	private int enabledCircle = 0;

	private void Awake()
	{
		foreach (RawImage circle in circles)
			circle.enabled = false;

		circles[enabledCircle].enabled = true;
	}

	public void update(int circle)
	{
		if (circle < 0 || circle > circles.Length)
			return;

		circles[enabledCircle].enabled = false;
		enabledCircle = circle;
		circles[enabledCircle].enabled = true;
	}

}
