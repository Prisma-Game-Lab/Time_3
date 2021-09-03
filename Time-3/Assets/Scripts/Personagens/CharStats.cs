using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] private CharacterBase charBase; //Referencia ao SO do personagem.
    [SerializeField] private SkillBase[] skills; //Array contendo as habilidades dos personagens. -Arthur 

    [SerializeField] private int maxHp;
    [SerializeField] private int defense;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int skillDmg;

    private int curr_hp;


    // Start is called before the first frame update
    void Awake()
    {
        //Status definidos a partir do SO. -Arthur
        maxHp = charBase.baseHp;
        defense = charBase.baseDefense;
        speed = charBase.baseSpeed;
        damage = charBase.baseDamage;
        skillDmg = charBase.baseSkillDmg;
        skills = charBase.Skills;
        curr_hp = maxHp; //Vida atual deve ser inicializada como a vida maxima. -Arthur 
    }
    
    //Funcoes para obter os valores das variaveis
    public int getMaxHp()
    {
        return maxHp;
    }

    public int getCurHp()
    {
        return curr_hp;
    }

    public int getDefense()
    {
        return defense;
    }

    public float getSpeed()
    {
        return speed;
    }

    public int getDamage()
    {
        return damage;
    }

    public int getSkillDmg()
    {
        return skillDmg;
    }
    public CharacterBase GetCharacterBase()
    {
        return charBase;
    }

    public SkillBase GetCombatSkill()
    {
        return skills[0];
    }

    public SkillBase GetExplorationSkill()
    {
        return skills[1];
    }

    //Funcoes para manipular os valores das vairaveis
    public void setMaxHp(int hp)
    {
        maxHp += hp;
        return;
    }

    public void setCurHp(int hp)
    {
        curr_hp += hp;
        return;
    }

    public void setDefense(int def)
    {
        defense += def;
        return;
    }

    public void setSpeed(int spd)
    {
        speed += spd;
        return;
    }

    public void setDamage(int dmg)
    {
        damage += dmg;
        return;
    }

    public void setSkillDmg(int sdmg)
    {
        skillDmg += sdmg;
        return;
    }
    public void setCharbase(CharacterBase cd)
    {
        charBase=cd;
        maxHp = charBase.baseHp;
        defense = charBase.baseDefense;
        speed = charBase.baseSpeed;
        damage = charBase.baseDamage;
        skillDmg = charBase.baseSkillDmg;
        
        curr_hp = maxHp;
        return;
    }

}
