using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dummy", menuName = "skills/dummy")]
public class Dummy : SkillBase
{
    public int dummy = 0;
    public int increase = 10;

    public override void TriggerSkill()
    {
       if(dummy == 0)
       {
           dummy += increase;
           Debug.Log(dummy);
       }
       else
       {
           dummy -= increase;
           Debug.Log(dummy);
       }
    }
}
