using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBehaviour : MonoBehaviour
{
    private CharStats charStats;
    public SkillBase[] skills;
    private float[] cooldown;
    private float[] activeTime;

    private void Awake() 
    {
        charStats = GetComponent<CharStats>();
        skills[0] = charStats.GetCombatSkill();
        skills[1] = charStats.GetExplorationSkill();

        for(int i = 0; i < 2; i++)
        {
            cooldown[i] = skills[i].skillCD;
            activeTime[i] = skills[i].activeTime;
        }
    }
    private void Update() 
    {
        foreach(SkillBase skill in skills)
        {
            int index = System.Array.IndexOf(skills, skill);
            switch(skill.state)
            {
                case "active":
                    if(activeTime[index] > 0)
                    {
                        activeTime[index] -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = "cooldown";
                        cooldown[index] = skill.skillCD;
                    }
                break;
                case "cooldown":
                    if(cooldown[index] > 0)
                    {
                        cooldown[index] -= Time.deltaTime;
                    }
                    else
                    {
                        skill.state = "ready";
                        activeTime[index] = skill.activeTime;
                    }
                break;
            }
        }

    }

    public void ActivateSkill(SkillBase skill)
    {
        if(skill.state == "ready")
        {
            skill.TriggerSkill(gameObject);
            skill.state = "active";
        }
    }
}
