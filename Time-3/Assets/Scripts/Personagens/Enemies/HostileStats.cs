using UnityEngine;

public class HostileStats : CharStats
{
	[SerializeField] private CharacterBase[] enemyBases;
	[SerializeField] private float dropValue;
	[SerializeField] private float fov;
	[SerializeField] private float viewDistance;
	[SerializeField] private float hearingDistance;
	[SerializeField] private SpriteRenderer spriteRenderer;

	protected override void Awake()
	{
		charBase = enemyBases[Random.Range(0,3)];
		base.Awake();
		dropValue = ((HostileBase)charBase).dropValue;
		fov = ((HostileBase)charBase).fov;
		viewDistance = ((HostileBase)charBase).viewDistance;
		hearingDistance = ((HostileBase)charBase).hearingDistance;
		spriteRenderer.sprite = ((HostileBase)charBase).sprite;
	}

	public float GetDropValue() => dropValue;
	public float GetFOV() => fov;
	public float GetViewDistance() => viewDistance;
	public float GetHearingDistance() => hearingDistance;

	public void SetDropValue(float dropValue) {
		if (dropValue >= 0.0f)
			this.dropValue = dropValue;
	}

	public void SetFOV(float fov) {
		if (fov >= 0.0f && fov <= 360.0f)
			this.fov = fov;
	}
	public void SetViewDistance(float viewDistance) {
		if (viewDistance >= 0)
			this.viewDistance = viewDistance;
	}

	public void SetHearingDistance(float hearingDistance) {
		if (hearingDistance >= 0)
			this.hearingDistance = hearingDistance;
	}
}
