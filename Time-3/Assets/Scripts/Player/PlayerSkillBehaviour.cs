using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBehaviour : MonoBehaviour
{
    private CharStats charStats;
    public SkillBase Cskill;
    public SkillBase Eskill;
    private float Ccooldown;
    private float Ecooldown;

    private float CactiveTime;
    private float EactiveTime;
    

    private void Awake() 
    {
        charStats = GetComponent<CharStats>();
    }

    private void Start() 
    {
        Cskill = charStats.GetCombatSkill();
        Eskill = charStats.GetExplorationSkill();

        Ecooldown = Eskill.skillCD;
        EactiveTime = Eskill.activeTime;

        Ccooldown = Cskill.skillCD;
        CactiveTime = Cskill.activeTime;
    }

    private void Update() 
    {
        switch(Cskill.state)
        {
            case "active":
                if(CactiveTime > 0)
                {
                    CactiveTime -= Time.deltaTime;
                }
                else
                {
                    Cskill.state = "cooldown";
                    Ccooldown = Cskill.skillCD;
                }
            break;
            case "cooldown":
                if(Ccooldown > 0)
                {
                    Ccooldown -= Time.deltaTime;
                }
                else
                {
                    Cskill.state = "ready";
                }
            break;
        }

        switch(Eskill.state)
        {
            case "active":
                if(EactiveTime > 0)
                {
                    EactiveTime -= Time.deltaTime;
                }
                else
                {
                    Eskill.state = "cooldown";
                    Ecooldown = Eskill.skillCD;
                }
            break;
            case "cooldown":
                if(Ecooldown > 0)
                {
                    Ecooldown -= Time.deltaTime;
                }
                else
                {
                    Eskill.state = "ready";
                }
            break;
        }
    }

    public void ActivateCombatSkill()
    {
        if(Cskill.state == "ready")
        {
            Cskill.TriggerSkill(gameObject);
            Cskill.state = "active";
            CactiveTime = Cskill.activeTime;
        }
    }

    public void ActivateExplorationSkill()
    {
        if(Eskill.state == "ready")
        {
            Eskill.TriggerSkill(gameObject);
            Eskill.state = "active";
            EactiveTime = Eskill.activeTime;
        }
    }
}
