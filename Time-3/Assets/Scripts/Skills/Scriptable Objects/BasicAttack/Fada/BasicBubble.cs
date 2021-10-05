using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicBubble", menuName = "BasicAttacks/Bubble")]
public class BasicBubble : SkillBase
{
    [SerializeField] private GameObject bubblePrefab;
    public float range;
    public float speed;
    private GameObject player;

    public override void TriggerSkill()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(bubblePrefab, player.transform.position + player.transform.right, player.transform.rotation * Quaternion.Euler(0,0,-20));
        Instantiate(bubblePrefab, player.transform.position + player.transform.right, player.transform.rotation * Quaternion.Euler(0,0,0));
        Instantiate(bubblePrefab, player.transform.position + player.transform.right, player.transform.rotation * Quaternion.Euler(0,0,20));
    }

    public override void StopSkill()
	{

	}
}
