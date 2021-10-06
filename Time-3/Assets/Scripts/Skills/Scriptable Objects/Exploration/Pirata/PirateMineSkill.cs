using UnityEngine;

[CreateAssetMenu(fileName = "PirateMine", menuName = "Exploration Skills/Pirate Mine")]
public class PirateMineSkill : SkillBase
{
	[SerializeField] private GameObject pirateMinePrefab;

	public override void TriggerSkill()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Instantiate(pirateMinePrefab, player.transform.position, Quaternion.identity);
	}

	public override void StopSkill()
	{

	}
}
