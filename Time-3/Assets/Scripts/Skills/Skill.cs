using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    //Variaveis que indicam quando a habilidade pode ser utilizada. -Arthur
    public float cooldown;
    public bool canUse = true;

    //Funcao que deve ser chamada em todas as outras skills para utiliza-las.
    //O corpo dela varia por skill, logo deve possuir o modificador override. -Arthur
    public abstract void TriggerSkill();

    //Corrotina que proibe o uso da skill ate o fim do cooldown.
    //Talvez o corpo varie dependendo da habilidade, mas por enquanto podemos deixar aqui. -Arthur
    public IEnumerator SkillCooldown(float cd)
    {
        canUse = false;
 
        yield return new WaitForSeconds(cd);

        canUse = true;
    }
}
