using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "BubbleShield", menuName = "Exploration Skills/Bubble Shield")]
public class BubbleShieldSkill : SkillBase
{
    [SerializeField] private GameObject shieldPrefab;

    private GameObject player;

    public override void TriggerSkill()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(shieldPrefab, player.transform.position + player.transform.right, player.transform.rotation);
    }

    public override void StopSkill()
	{

	}
}
