using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public float skillCD;
    public float activeTime;

    public string state = "ready";
    public abstract void TriggerSkill();
    public abstract void StopSkill();
}
