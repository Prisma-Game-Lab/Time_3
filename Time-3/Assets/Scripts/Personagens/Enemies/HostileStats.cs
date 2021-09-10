using UnityEngine;

public class HostileStats : CharStats
{
	[SerializeField] private float dropValue;

	protected override void Awake()
	{
		base.Awake();
		dropValue = ((HostileBase)charBase).dropValue;
	}

	public float GetDropValue() => dropValue;

	public void SetDropValue(float dropValue) =>  this.dropValue = dropValue < 0 ? 0 : dropValue;
}
