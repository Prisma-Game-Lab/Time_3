using UnityEngine;

public class PlayerInventoryBehaviour : MonoBehaviour
{
	[SerializeField] private float credits = 0.0f;

	public float GetCredits() => credits;

	public void SetCredits(float credits) => this.credits = credits < 0 ? 0 : credits;

	public void IncCredits(float credits)
	{
		this.credits += credits;
		if (this.credits < 0)
			this.credits = 0;
	}
}
