using UnityEngine;

public class HostileStats : CharStats
{
	[SerializeField] private float dropValue;
	[SerializeField] private float fov;
	[SerializeField] private float viewDistance;
	[SerializeField] private float hearingDistance;

	protected override void Awake()
	{
		base.Awake();
		dropValue = ((HostileBase)charBase).dropValue;
		fov = ((HostileBase)charBase).fov;
		viewDistance = ((HostileBase)charBase).viewDistance;
		hearingDistance = ((HostileBase)charBase).hearingDistance;
	}

	public float GetDropValue() => dropValue;
	public float GetFOV() => fov;
	public float GetViewDistance() => viewDistance;
	public float GetHearingDistance() => hearingDistance;

	public void SetDropValue(float dropValue) =>  this.dropValue = dropValue < 0 ? 0 : dropValue;
	public void SetFOV(float fov) => this.fov = fov;
	public void SetViewDistance(float viewDistance) => this.viewDistance = viewDistance;
	public void SetHearingDistance(float hearingDistance) => this.hearingDistance = hearingDistance;
}
